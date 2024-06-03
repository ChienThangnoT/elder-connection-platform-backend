using Application;
using Application.IServices;
using Application.ViewModels.JobScheduleViewModels;
using Application.ViewModels.PostViewModels;
using Application.ViewModels.RequestViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController :ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostService _postService;

        public PostController(IUnitOfWork unitOfWork, IPostService postService)
        {
            _unitOfWork = unitOfWork;
            _postService = postService;
        }

        [HttpPost("create-post")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            var result = await _postService.CreatePostAsync(request.PostCreateViewModel, request.JobScheduleCreateViewModel);
            return Ok(result);
        }
    }
}
