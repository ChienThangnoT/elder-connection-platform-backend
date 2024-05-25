using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #region Detail
        [HttpGet("get-account-detail{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            try
            {
                var user = await _accountService.GetUserDetailAsync(id);

                // return status codes with result according to user object
                return (user == null) ? NotFound(new FailedResponseModel
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Account not found.",
                })
                    :
                Ok(user);
            }
            catch (ArgumentException ex)
            {
                // return status code bad request for validation
                return BadRequest(new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Invalid parameters.",
                    Errors = ex.Message
                });
            }
        }
        #endregion
    }
}
