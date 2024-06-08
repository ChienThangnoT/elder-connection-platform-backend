using Application.IServices;
using Application.ViewModels.ElderInformationViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ElderInformationController : ControllerBase
	{
		private readonly IElderInformationService _elderInformationService;

		public ElderInformationController(IElderInformationService elderInformationService)
		{
			_elderInformationService = elderInformationService;
		}

		#region Get Elder Information by Child Id
		[HttpGet("get-elder-information-by-child/{childId}")]
		public async Task<IActionResult> GetElderInformationByChildIdAsync(string childId)
		{
			var result = await _elderInformationService.GetElderInformationByChildIdAsync(childId);
			return Ok(result);
		}
		#endregion

		#region Update Elder Information
		[HttpPut("update-elder-information/{id}")]
		public async Task<IActionResult> UpdateElderInformationAsync(int id, ElderInformationUpdateModel elderInformationUpdateModel)
		{
			var result = await _elderInformationService.UpdateElderInformationAsync(id, elderInformationUpdateModel);
			return Ok();
		}
		#endregion
	}
}
