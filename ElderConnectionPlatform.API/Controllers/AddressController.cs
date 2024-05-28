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
    }
}
