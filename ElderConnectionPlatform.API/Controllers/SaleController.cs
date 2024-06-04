using Application.IServices;
using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.ResponseModels;
using Application.ViewModels.SaleViewModels;
using Application.Services;
using Infracstructures.Mappers;

namespace ElderConnectionPlatform.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SaleController : ControllerBase
	{
		private readonly ISaleService _saleService;

		public SaleController(ISaleService saleService)
		{
			_saleService = saleService;
		}

		#region Create sale
		[HttpPost("create-sale")]
		public async Task<IActionResult> CreatedSaleAsync(SaleAddModel saleAddModel)
		{
			try
			{
				var result = await _saleService.AddSaleAsync(saleAddModel);

				return Ok(result);
			}
			catch (ArgumentException ex)
			{
				// return status code bad request for validation
				return BadRequest(new FailedResponseModel
				{
					Status = StatusCodes.Status400BadRequest,
					Message = "Invalid parameters.",
					Errors = ex.Message
				});
			}
		}
		#endregion

		#region Get All Sale
		[HttpGet("get-all-sale")]
		public async Task<IActionResult> GetAllSaleAsync(int pageIndex = 0, int pageSize = 10)
		{
			var result = await _saleService.GetAllSaleAsync(pageIndex, pageSize);
			return Ok(result);
		}
		#endregion

		#region Get Sale by Id
		[HttpGet("get-sale-by-id/{saleId}")]
		public async Task<IActionResult> GetSaleByIdAsync(int saleId)
		{
			var result = await _saleService.GetSaleByIdAsync(saleId);
			return Ok(result);
		}
		#endregion

		#region Update Sale By Id
		[HttpPut("update-sale-by-id/{saleId}")]
		public async Task<IActionResult> UpdateSaleByIdAsync(int saleId, SaleUpdateModel saleUpdateModel)
		{
			var result = await _saleService.UpdateSaleAsync(saleId, saleUpdateModel);
			return Ok(result);
		}
		#endregion

		#region Remove Sale By Id
		[HttpDelete("remove-sale-by-id/{saleId}")]
		public async Task<IActionResult> RemoveSaleByIdAsync(int saleId)
		{
			var result = await _saleService.RemoveSaleAsync(saleId);
			return Ok(result);
		}
		#endregion
	}
}
