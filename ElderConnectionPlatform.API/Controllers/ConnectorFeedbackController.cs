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
		public async Task<IActionResult> GetFeedbackViewModelAsync(string connectorId, int pageIndex, int pageSize)
		{
			var response = await _connectorFeedbackService.GetFeedbackViewModelAsync(connectorId, pageIndex, pageSize);
			return StatusCode(response.Status, response);
		}
	}
}
