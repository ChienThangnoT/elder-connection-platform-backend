using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Application.ViewModels.AccountViewModels;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp(AccountSignUpModel accountSignUpModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.SignUpAsync(accountSignUpModel);
                    if (result == true)
                    {
                        return Ok(new SuccessResponseModel()
                        {
                            Status = Ok().StatusCode,
                            Message = "Account signup success",
                            Result = new {User = accountSignUpModel}
                        });
                    }
                    return BadRequest(new FailedResponseModel
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Create account failed",
                        Errors = result
                    });
                }
                return ValidationProblem(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message =  ex.Message
                });
            }
        }
    }
}
