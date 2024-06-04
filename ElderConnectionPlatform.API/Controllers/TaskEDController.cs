using Application.IServices;
using Application;
using Microsoft.AspNetCore.Mvc;
using Application.Exceptions;
using Application.ResponseModels;
using Application.Services;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskEDController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskEDService _taskEDService;

        public TaskEDController(IUnitOfWork unitOfWork, ITaskEDService taskEDService)
        {
            _unitOfWork = unitOfWork;
            _taskEDService = taskEDService;
        }

        #region Get all task by connector id
        [HttpGet("get-all-task-by-connector-id/{connectorId}")]
        public async Task<IActionResult> GetAllTaskByConnectorId
            (string connectorId, int pageIndex = 0, int pageSize = 10)
        {
            try
            {
                var taskEDs = await _taskEDService.GetTaskEDListByConnectorIdAsync(connectorId, pageIndex, pageSize);

                return taskEDs == null
                    ? throw new NotExistsException()
                    : (IActionResult)Ok(taskEDs);
            }
            catch (Exception ex)
            {
                return BadRequest(new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Bad request.",
                    Errors = ex.Message
                });
            }
        }
        #endregion

        #region Get task by id
        [HttpGet("get-task-by-id/{taskId}")]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            try
            {
                var taskED = await _taskEDService.GetTaskEDByIdAsync(taskId);
                return Ok(taskED);
            }
            catch (Exception ex)
            {
                return BadRequest(new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Bad request.",
                    Errors = ex.Message
                });
            }
        }
        #endregion
    }
}
