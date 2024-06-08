using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ConnectorFeedbackController : ControllerBase
	{
		private readonly IConnectorFeedbackService _connectorFeedbackService;

		public ConnectorFeedbackController(IConnectorFeedbackService connectorFeedbackService)
		{
			_connectorFeedbackService = connectorFeedbackService;
		}

		[HttpGet("{connectorId}")]
		public async Task<IActionResult> GetFeedbackViewModelAsync(string connectorId)
		{
			var response = await _connectorFeedbackService.GetFeedbackViewModelAsync(connectorId);
			return StatusCode(response.Status, response);
		}
	}
}
