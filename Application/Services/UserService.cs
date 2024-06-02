using Application.Exceptions;
using Application.IRepositories;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.AccountViewModels;
using AutoMapper;
using Domain.Enums.AccountEnums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<Account> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Account> _userManager;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuration,
            UserManager<Account> userManager,
            SignInManager<Account> signInManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }


        #region signup account
        public async Task<BaseResponseModel> SignUpAsync(AccountSignUpModel model)
        {
            var exsistAccount = await _userManager.FindByNameAsync(model.AccountEmail);

            if (exsistAccount != null)
            {
                throw new AccountAlreadyExistsException();
            }

            var user = new Account
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Status = (int)AccountStatus.Active,
                UserName = model.AccountEmail,
                Email = model.AccountEmail,
                PhoneNumber = model.AccountPhone,
                CreateAt = DateTime.Now,
            };
            var result = await _userManager.CreateAsync(user, model.AccountPassword);

            string errorMessage = null;
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(RoleAccountModel.Customer.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleAccountModel.Customer.ToString()));
                }
                if (await _roleManager.RoleExistsAsync(RoleAccountModel.Customer.ToString()))
                {
                    await _userManager.AddToRoleAsync(user, RoleAccountModel.Customer.ToString());
                }
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                return new EmailTokenModel
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Create account successfull",
                    ConfirmEmailToken = token
                };
            }
            foreach (var ex in result.Errors)
            {
                errorMessage = ex.Description;
            }
            return new FailedResponseModel { Status = StatusCodes.Status400BadRequest, Message = errorMessage };
        }

        #endregion

        #region confirm email
        public async Task<BaseResponseModel> ConfirmEmail(string email, string token)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user == null)
            {
                throw new NotExistsException();
            }

            if (user.EmailConfirmed)
            {
                return new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Email đã được xác nhận!"
                };

            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return new SuccessResponseModel
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Xác thực email thành công!"
                };
            }
            return new FailedResponseModel
            {
                Status = StatusCodes.Status400BadRequest,
                Message = "Xác thực email thất bại!"
            };
        }
        #endregion

        #region config login and jwt
        public async Task<BaseResponseModel> SignInAccountAsync(SignInModel model)
        {
            var account = await _userManager.FindByNameAsync(model.AccountEmail);
            var result = await _signInManager.PasswordSignInAsync(model.AccountEmail, model.AccountPassword, false, false);


            if (result.Succeeded)
            {
                return await GenerateAuthenticationResponse(account);
            }
            else if (result.IsNotAllowed)
            {
                var token = _userManager.GenerateEmailConfirmationTokenAsync(account);
                return new AuthenticationResponseModel
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Message = "Email xác nhận đã được gửi đến tài khoản email bạn đã đăng ký, vui lòng xác thực tài khoản để đăng nhập!",
                    VerifyEmailToken = token
                };
            }
            else if (result.IsLockedOut)
            {
                return new AuthenticationResponseModel
                {
                    Status = StatusCodes.Status423Locked,
                    Message = "Tài khoản của bạn đã bị khóa. Vui lòng thử lại sau."
                };
            }
            else if (result.RequiresTwoFactor)
            {
                return new AuthenticationResponseModel
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Message = "Yêu cầu xác thực hai yếu tố."
                };
            }
            else
            {
                return new AuthenticationResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Đăng nhập thất bại. Email hoặc mật khẩu không đúng."
                };
            }
        }


        private async Task<AuthenticationResponseModel> GenerateAuthenticationResponse(Account account)
        {
            if (account == null)
            {
                throw new NotExistsException();
            }

            var authClaims = await GetAuthClaims(account);
            var token = CreateToken(authClaims);
            var refreshToken = GenerateRefreshToken();

            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            account.RefreshToken = refreshToken;
            account.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await _userManager.UpdateAsync(account);

            return new AuthenticationResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Login successfully!",
                JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expired = TimeZoneInfo.ConvertTimeFromUtc(token.ValidTo, TimeZoneInfo.Local),
                JwtRefreshToken = refreshToken
            };
        }

        private async Task<List<Claim>> GetAuthClaims(Account user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            return authClaims;
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }


        public async Task<BaseResponseModel> RefreshToken(TokenModel tokenModel)
        {
            if (tokenModel is null)
            {
                return new AuthenticationResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Request not valid!"
                };
            }

            string accessToken = tokenModel.AccessToken;
            string refreshToken = tokenModel.RefreshToken;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                return new AuthenticationResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Invalid access token or refresh token!"
                };
            }

            string username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return new AuthenticationResponseModel
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Message = "Invalid access token or refresh token!"
                };
            }

            var newAccessToken = CreateToken(principal.Claims.ToList());
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new AuthenticationResponseModel
            {
                Status = StatusCodes.Status201Created,
                Message = "Refresh Token successfully!",
                JwtToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                Expired = newAccessToken.ValidTo,
                JwtRefreshToken = newRefreshToken
            };
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"])),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Token unavailabel!");
            return principal;
        }
        #endregion

        #region signup connector account
        public async Task<BaseResponseModel> SignUpConnectorAsync(AccountSignUpModel model)
        {
            var exsistAccount = await _userManager.FindByNameAsync(model.AccountEmail);

            if (exsistAccount != null)
            {
                throw new AccountAlreadyExistsException();
            }

            var user = new Account
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Status = (int)AccountStatus.Active,
                UserName = model.AccountEmail,
                Email = model.AccountEmail,
                PhoneNumber = model.AccountPhone,
                CreateAt = DateTime.Now,
            };
            var result = await _userManager.CreateAsync(user, model.AccountPassword);

            string errorMessage = null;
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(RoleAccountModel.Connector.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleAccountModel.Connector.ToString()));
                }
                if (await _roleManager.RoleExistsAsync(RoleAccountModel.Connector.ToString()))
                {
                    await _userManager.AddToRoleAsync(user, RoleAccountModel.Connector.ToString());
                }
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                return new EmailTokenModel
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Create account successfull",
                    ConfirmEmailToken = token
                };
            }
            foreach (var ex in result.Errors)
            {
                errorMessage = ex.Description;
            }
            return new FailedResponseModel { Status = StatusCodes.Status400BadRequest, Message = errorMessage };
        }

        #endregion

    }
}