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
using System;
using System.Collections.Generic;
using System.Linq;
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
                return new TokenModel
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Create account successfull, Please confirm your email to login into eHubSystem",
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


    }
}