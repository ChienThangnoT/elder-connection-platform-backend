﻿using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Application.ViewModels.AccountViewModels;
using Domain.Models;
using ElderConnectionPlatform.API.Helper;
using Application.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly IAccountService _accountService;

        public UserController(IUserService userService, IMailService mailService, IAccountService accountService)
        {
            _userService = userService;
            _mailService = mailService;
            _accountService = accountService;
        }

        #region Sign Up Account
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(AccountSignUpModel accountSignUpModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }

                var result = await _userService.SignUpAsync(accountSignUpModel);
                if (result.Status == 400)
                {
                    return BadRequest(result);
                }

                var token = (result as EmailTokenModel)?.ConfirmEmailToken;
                var url = Url.Action("ConfirmEmail", "user", new { memberEmail = accountSignUpModel.AccountEmail, tokenReset = token }, Request.Scheme);

                var messageRequest = new EmailRequest
                {
                    To = accountSignUpModel.AccountEmail,
                    Subject = "Xác nhận email cho việc đăng kí vào ứng dụng",
                    Content = MailTemplate.ConfirmTemplate(accountSignUpModel.AccountEmail, url)
                };

                await _mailService.SendConFirmEmailAsync(messageRequest);

                return Ok(new SuccessResponseModel()
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Create account successfull, Please confirm your email to login into eHubSystem",
                    Result = new { User = accountSignUpModel }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        #endregion

        #region Confirm Email
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string tokenReset, string memberEmail)
        {
            try
            {
                var result = await _userService.ConfirmEmail(memberEmail, tokenReset);
                if (result.Status.Equals(false))
                {
                    return Unauthorized(result);
                }
                var account = await _accountService.GetAccountByEmailAsync(memberEmail);
                if (account != null)
                {
                    return Redirect("https://www.google.com/");
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest("Confirm email failed!");
            }
        }
        #endregion

        #region send email
        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromForm] EmailRequest email)
        {
            try
            {
                await _mailService.SendEmailAsync(email);
                return Ok("Test");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Sign in
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.SignInAccountAsync(signInModel);
                    if (result.Status.Equals(false))
                    {
                        return Unauthorized(result);
                    }
                    return Ok(result);
                }
                return ValidationProblem(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region generate refresh token
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel model)
        {

            var result = await _userService.RefreshToken(model);
            if (result.Status.Equals(false))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        #endregion

        #region Sign Up Connector Account
        [HttpPost("sign-up-connector")]
        public async Task<IActionResult> SignUpConnector(ConnectorSignUpModel connectorSignUpModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }

                var result = await _userService.SignUpConnectorAsync(connectorSignUpModel);
                if (result.Status == 400)
                {
                    return BadRequest(result);
                }

                var token = (result as EmailTokenModel)?.ConfirmEmailToken;
                var url = Url.Action("ConfirmEmail", "user", new { memberEmail = connectorSignUpModel.AccountEmail, tokenReset = token }, Request.Scheme);

                var messageRequest = new EmailRequest
                {
                    To = connectorSignUpModel.AccountEmail,
                    Subject = "Xác nhận email cho việc đăng kí vào ứng dụng",
                    Content = MailTemplate.ConfirmTemplate(connectorSignUpModel.AccountEmail, url)
                };

                await _mailService.SendConFirmEmailAsync(messageRequest);

                return Ok(new SuccessResponseModel()
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Create account successfull, Please confirm your email to login into eHubSystem",
                    Result = new { User = connectorSignUpModel }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

    }
}
