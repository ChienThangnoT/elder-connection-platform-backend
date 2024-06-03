using Application;
using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Application.ViewModels.AddressViewModels;
using Application.ViewModels.ConnectorInfoViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/elder-connector-infos")]
    [ApiController]
    public class ElderConnectorInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConnectorInfoService _connectorInfoService;

        public ElderConnectorInfoController(IUnitOfWork unitOfWork, IConnectorInfoService connectorInfoService)
        {
            _unitOfWork = unitOfWork;
            _connectorInfoService = connectorInfoService;
        }

        [HttpPost("become-connector")]
        public async Task<IActionResult> ApplyBecomConnectorAsync(string accountId, ApplyModel model)
        {
            try
            {
                var result = await _connectorInfoService.ApplyBecomConnectorAsync(accountId, model);

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
