using Application;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Application.ViewModels.AddressViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressService _addressService;

        public AddressController(IUnitOfWork unitOfWork, IAddressService addressService)
        {
            _unitOfWork = unitOfWork;
            _addressService = addressService;
        }

        #region Create account address
        [HttpPost("create-address")]
        public async Task<IActionResult> CreatedAddress(AddressAddModel addressAddModel)
        {
            try
            {
                var result = await _addressService.AddAccountAddressAsync(addressAddModel);

                return Ok(result);
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

        #region Get Account Address By Account Id
        [HttpGet("get-all-address-by-account/{accountId}")]
        public async Task<IActionResult> GetServiceTypeById(string accountId, int pageSize = 0, int pageIndex = 10)
        {
            var result = await _addressService.GetAccountAddressByAccountIdAsync(accountId, pageSize, pageIndex);
            return Ok(result);
        }
        #endregion

        #region Update Account Address By Id
        [HttpPut("update-account-address/{addressId}")]
        public async Task<IActionResult> UpdateAccountAddressAsync(int addressId, AddressUpdateModel addressUpdateModel)
        {
            var result = await _addressService.UpdateAccountAddressAsync(addressId, addressUpdateModel);
            return Ok(result);
        }
        #endregion

    }
}
