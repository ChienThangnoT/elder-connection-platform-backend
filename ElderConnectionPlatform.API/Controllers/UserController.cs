using Application.IServices;
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
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;

        public UserController(IUserService userService, IMailService mailService)
        {
            _userService = userService;
            _mailService = mailService;
        }


        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(AccountSignUpModel accountSignUpModel)
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

            var token = (result as TokenModel)?.ConfirmEmailToken;
            var url = Url.Action("ConfirmEmail", "Account", new { memberEmail = accountSignUpModel.AccountEmail, tokenReset = token }, Request.Scheme);

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
                Message = "Account signup success",
                Result = new { User = accountSignUpModel }
            });
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string tokenReset, string memberEmail)
        {
            try
            {
                var result = await _userService.ConfirmEmail(memberEmail, tokenReset);
                if (result.Status.Equals(false))
                {
                    return Unauthorized(result);
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest("Confirm email failed!");
            }
        }

        [HttpPost("Send-email")]
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
    }
}
