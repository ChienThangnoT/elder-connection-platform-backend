using Application.IServices;
using Application.ViewModels.ConnectorFeedbackViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
	[Route("api/connector-feedbacks")]
	[ApiController]
	public class ConnectorFeedbackController : ControllerBase
	{
		private readonly IConnectorFeedbackService _connectorFeedbackService;

		public ConnectorFeedbackController(IConnectorFeedbackService connectorFeedbackService)
		{
			_connectorFeedbackService = connectorFeedbackService;
		}

		//[HttpGet("{connectorId}")]
		//public async Task<IActionResult> GetFeedbackViewModelAsync(string connectorId)
		//{
		//	var response = await _connectorFeedbackService.GetFeedbackViewModelAsync(connectorId);
		//	return StatusCode(response.Status, response);
		//}

		[HttpGet("{connectorId}")]
		public async Task<IActionResult> GetFeedbackViewModelAsync(string connectorId, int pageIndex = 0, int pageSize = 10)
		{
			var response = await _connectorFeedbackService.GetFeedbackViewModelPaginationAsync(connectorId, pageIndex, pageSize);
			return StatusCode(response.Status, response);
		}

        [HttpPost("rate")]
        public async Task<IActionResult> RateConnectorAsync(RateConnectorViewModel rateConnectorViewModel)
        {
            var response = await _connectorFeedbackService.RateConnectorAsync(rateConnectorViewModel);
            return StatusCode(response.Status, response);
        }
    }
}
