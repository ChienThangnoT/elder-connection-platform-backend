using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Application.ViewModels.TrainingProgramViewModels;
using Infracstructures.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TrainingProgramController : ControllerBase
	{
		private readonly ITrainingProgramService _trainingProgramService;

		public TrainingProgramController(ITrainingProgramService trainingProgramService)
		{
			_trainingProgramService = trainingProgramService;
		}


		#region Get All Training Program
		[HttpGet("get-all-training-program")]
		public async Task<IActionResult> GetAllTrainingProgramAsync(int pageIndex = 0, int pageSize = 10)
		{
			var result = await _trainingProgramService.GetAllTrainingProgramAsync(pageIndex, pageSize);
			return Ok(result);
		}
		#endregion


		#region Create Training Program
		[HttpPost("create-training-program")]
		public async Task<IActionResult> CreatedTrainingProgramAsync(TrainingProgramAddModel trainingProgramAddModel)
		{
			try
			{
				var result = await _trainingProgramService.AddTrainingProgramAsync(trainingProgramAddModel);

				return Ok(result);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(new FailedResponseModel
				{
					Status = StatusCodes.Status400BadRequest,
					Message = "Invalid parameters.",
					Errors = ex.Message
				});
			}
		}
		#endregion


		#region Update Training Program By Id
		[HttpPut("update-training-program/{trainingProgramId}")]
		public async Task<IActionResult> UpdateTrainingProgramByIdAsync(int trainingProgramId, TrainingProgramUpdateModel trainingProgramUpdateModel)
		{
			var result = await _trainingProgramService.UpdateTrainingProgramAsync(trainingProgramId, trainingProgramUpdateModel);
			return Ok(result);
		}
		#endregion

		#region Remove Training Program By Id
		[HttpDelete("remove-training-program/{trainingProgramId}")]
		public async Task<IActionResult> RemoveTrainingProgramIdByIdAsync(int trainingProgramId)
		{
			var result = await _trainingProgramService.RemoveTrainingProgramAsync(trainingProgramId);
			return Ok(result);
		}
		#endregion
	}
}
