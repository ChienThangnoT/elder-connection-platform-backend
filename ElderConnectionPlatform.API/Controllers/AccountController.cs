using Application.Exceptions;
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
        [HttpGet("get-account-detail/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _accountService.GetUserDetailAsync(id);
            return Ok(user);
        }
        #endregion

        #region Update
        [HttpPut("update-account-detail/{id}")]
        public async Task<IActionResult> UpdateProfile(string id, [FromBody] AccountUpdateModel model)
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
        #endregion

        #region Get list account
        [HttpGet("list-account-pagination")]
        public async Task<IActionResult> GetLisAccountt(int pageIndex = 0, int pageSize = 10)
        {
            try
            {
                var usersList = await _accountService.GetUserListPaginationAsync(pageIndex, pageSize);

                if (usersList == null)
                {
                    throw new NotExistsException();
                }

                return (usersList.Items.Count == 0) ?
                    NoContent()
                    :
                    Ok(new SuccessResponseModel
                    {
                        Status = StatusCodes.Status200OK,
                        Message = "Succeed.",
                        Result = usersList
                    });
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

        #region Active or Inactive account
        [HttpPut("active-inactive-account/{id}")]
        public async Task<IActionResult> ActiveOrInactiveAccount(string id)
        {
            var result = await _accountService.ActiveOrInactiveAccount(id);
            return Ok(result);
        }
		#endregion

		#region Get wallet balance
		[HttpGet("get-wallet-balance/{accountId}")]
		public async Task<IActionResult> GetWalletBalance(string accountId)
		{
			var result = await _accountService.GetUserWalletBalance(accountId);
			return Ok(result);
		}
		#endregion
	}
}