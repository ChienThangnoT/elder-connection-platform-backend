using Application;
using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Application.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/servicetypes")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceTypeService _serviceTypeService;

        public ServiceTypeController(IUnitOfWork unitOfWork, IServiceTypeService serviceTypeService)
        {
            _unitOfWork = unitOfWork;
            _serviceTypeService = serviceTypeService;
        }

        #region Get Service Type By Id
        [HttpGet("get-service-type/{id}")]
        public async Task<IActionResult> GetServiceTypeById(int id)
        {
            var result = await _serviceTypeService.GetServiceTypeById(id);
            return Ok(result);
        }
        #endregion
    }
}
