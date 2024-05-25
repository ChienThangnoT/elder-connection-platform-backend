using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Application.ViewModels.AccountViewModels;
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

        #region Update
        [HttpPut("update-account-detail{id}")]
        public async Task<IActionResult> UpdateProfile(string id, [FromBody] AccountUpdateModel model)
        {
            try
            {
                var user = await _accountService.UpdateUserDetailASync(id, model);

                return (user == null) ? NotFound(new FailedResponseModel
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Account not found with id: " + id,
                })
                    :
                Ok(new SuccessResponseModel
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Update succeed.",
                    Result = user
                });
            }
            catch (Exception ex)
            {
                // return status code bad request for validation
                return BadRequest(new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Bad Request",
                    Errors = ex.Message
                });
            }
        }
        #endregion
    }
}
