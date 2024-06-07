using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.JobScheduleViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/jobschedules")]
    [ApiController]
    public class JobScheduleController : ControllerBase
    {
        private readonly IJobScheduleService _jobScheduleService;

        public JobScheduleController(IJobScheduleService jobScheduleService)
        {
            _jobScheduleService = jobScheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobScheduleViewModel>>> GetAllJobSchedules()
        {
            var jobSchedules = await _jobScheduleService.GetAllJobSchedulesAsync();
            return Ok(jobSchedules);
        }

        [HttpGet("get-job-schedule/{id}")]
        public async Task<ActionResult<JobScheduleViewModel>> GetJobScheduleById(int id)
        {
            var jobSchedule = await _jobScheduleService.GetJobScheduleByIdAsync(id);
            if (jobSchedule == null)
            {
                return NotFound();
            }
            return Ok(jobSchedule);
        }
    }
}
