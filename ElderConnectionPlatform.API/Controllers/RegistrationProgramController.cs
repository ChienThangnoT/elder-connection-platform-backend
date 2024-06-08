using Application.IServices;
using Application.ViewModels.RegistrationProgramViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/registration-programs")]
    [ApiController]
    public class RegistrationProgramController : ControllerBase
    {
        private readonly IRegistrationProgramService _registrationProgramService;

        public RegistrationProgramController(IRegistrationProgramService registrationProgramService)
        {
            _registrationProgramService = registrationProgramService;
        }

        [HttpPost("apply-registration-program")]
        public async Task<IActionResult> Apply(TrainingProgramApplyViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _registrationProgramService.ApplyTrainingProgram(request.TraningProgramId, request.ConnectorId);

            if (response.Status != StatusCodes.Status200OK)
                return StatusCode(response.Status, response.Message);

            return Ok(response);
        }
    }
}
