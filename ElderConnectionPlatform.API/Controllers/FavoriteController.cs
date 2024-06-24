using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Application.ViewModels.FavoriteListViewModels;
using Application.ViewModels.JobScheduleViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/favorite-lists")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }


        [HttpGet("get-favorite-list/{favoriteId}")]
        public async Task<IActionResult> GetFavoriteListById(int favoriteId)
        {
            var favorite = await _favoriteService.GetFavoriteListByIdAsync(favoriteId);
            return favorite == null
               ? NotFound()
               : Ok(favorite);
        }

        [HttpGet("get-favorite-list-by-customer-id/{customerId}")]
        public async Task<IActionResult> GetFavoriteListByCustomerId(string customerId, int pageIndex = 0, int pageSize = 10)
        {
            var favorites = await _favoriteService.GetFavoriteListByCustomerIdAsync(customerId, pageIndex, pageSize);
            return favorites == null
               ? NotFound()
               : Ok(favorites);
        }

        [HttpPost("create-favorite-list")]
        public async Task<IActionResult> CreateFavoriteList(FavoriteListCreateViewModel favoriteListCreateViewModel)
        {
            var result = await _favoriteService.CreateConnectorToFavoriteListAsync(favoriteListCreateViewModel);
            return Ok(result);
        }
    }
}
