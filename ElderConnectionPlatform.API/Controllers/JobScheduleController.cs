using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Application.ViewModels.JobScheduleViewModels;
using Domain.Models;
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

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<JobScheduleViewModel>>> GetAllJobSchedules()
        //{
        //    var jobSchedules = await _jobScheduleService.GetAllJobSchedulesAsync();
        //    return Ok(jobSchedules);
        //}

        [HttpGet("get-all-job-schedule")]
        public async Task<IActionResult> GetAllTrainingProgramAsync(int pageIndex = 0, int pageSize = 10)
        {
            var result = await _jobScheduleService.GetAllJobScheduleAsync(pageIndex, pageSize);
            return Ok(result);
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

        [HttpGet("get-job-schedule-by-connector-id/{connectorId}")]
        public async Task<IActionResult> GetAllJobScheduleByConnectorId
            (string connectorId, int pageIndex = 0, int pageSize = 10)
        {
            var jobSchedule = await _jobScheduleService.GetJobScheduleByConnectorIdAsync
                (connectorId, pageIndex, pageSize);

            return jobSchedule == null
               ? NotFound()
               : (IActionResult)Ok(jobSchedule);

        }

        [HttpGet("get-job-schedule-task-progress/{id}")]
        public async Task<IActionResult> GetJobScheduleTaskProgress(int id)
        {
            var jobSchedule = await _jobScheduleService.GetJobScheduleProcessAsync(id);

            return jobSchedule == null
               ? NotFound()
               : (IActionResult)Ok(jobSchedule);
        }
    }
}
