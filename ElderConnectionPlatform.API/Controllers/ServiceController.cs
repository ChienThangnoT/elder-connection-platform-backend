using Application;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceService _serviceService;

        public ServiceController(IUnitOfWork unitOfWork, IServiceService serviceService)
        {
            _unitOfWork = unitOfWork;
            _serviceService = serviceService;
        }

        #region Get List Service
        [HttpGet("list-service-pagination")]
        public async Task<IActionResult> GetListService(int pageIndex = 0, int pageSize = 10)
        {
            try
            {
                var serviceList = await _serviceService.GetAllServiceListPaginationAsync(pageIndex, pageSize);

                if (serviceList == null)
                {
                    throw new NotExistsException();
                }

                return (serviceList.Items.Count == 0) ?
                    NoContent()
                    :
                    Ok(new SuccessResponseModel
                    {
                        Status = StatusCodes.Status200OK,
                        Message = "Succeed.",
                        Result = serviceList
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

        #region Get Service By Id
        [HttpGet("get-service/{id}")]
        public async Task<IActionResult> GetServiceTypeById(int id)
        {
            var result = await _serviceService.GetServiceById(id);
            return Ok(result);
        }
        #endregion
    }
}
