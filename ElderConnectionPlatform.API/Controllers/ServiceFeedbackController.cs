using Application.IRepositories;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServiceFeedbackController : ControllerBase
	{
		private readonly IServiceFeedbackRepository _serviceFeedbackRepository;

		public ServiceFeedbackController(IServiceFeedbackRepository serviceFeedbackRepository)
		{
			_serviceFeedbackRepository = serviceFeedbackRepository;
		}

		[HttpGet("{serviceFeedbackId}")]
		public async Task<IActionResult> GetFeedbackByServiceIdAsync(int serviceFeedbackId)
		{
			var response = await _serviceFeedbackRepository.GetFeedbackByServiceIdAsync(serviceFeedbackId);
			return Ok(response);
		}

		
	}
}
