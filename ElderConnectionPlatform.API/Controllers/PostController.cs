using Application;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.JobScheduleViewModels;
using Application.ViewModels.PostViewModels;
using Application.ViewModels.MultiRequestViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using Application.Exceptions;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostService _postService;

        public PostController(IUnitOfWork unitOfWork, IPostService postService)
        {
            _unitOfWork = unitOfWork;
            _postService = postService;
        }
        #region Create post
        [HttpPost("create-post")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            try
            {
                var result = await _postService.CreatePostAsync
                (request.PostCreateViewModel, request.JobScheduleCreateViewModel);
                return Ok(result);
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

        #region Delete post
        [HttpDelete("delete-post/{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            var result = await _postService.DeletePostAsync(postId);
            return Ok(result);
        }
        #endregion

        #region Update post by id
        [HttpPut("update-post/{postId}")]
        public async Task<IActionResult> UpdatePost(int postId,
            [FromBody] UpdatePostRequest request)
        {
            var result = await _postService.UpdatePostAsync(
                postId,
                request.PostUpdateViewModel,
                request.JobScheduleUpdateViewModel);
            return Ok(result);
        }
        #endregion

        #region Get all posts
        [HttpGet("get-all-posts")]
        public async Task<IActionResult> GetAllPosts(int pageIndex = 0, int pageSize = 10)
        {
            try
            {
                var posts = await _postService.GetPostListPaginationAsync(pageIndex, pageSize);

                if (posts == null)
                    throw new NotExistsException();
                return (posts.Items.Count == 0) ?
                    NoContent():
                    Ok(posts);
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

        #region Get post by customer id
        [HttpGet("get-post-by-customer-id/{customerId}")]
        public async Task<IActionResult> GetPostByCustomerId(string customerId, int pageIndex = 0, int pageSize = 10)
        {
            try
            {
                var posts = await _postService.GetAllPostByCustomerIdAsync(customerId, pageIndex, pageSize);

                return posts == null
                    ? throw new NotExistsException()
                    : (IActionResult)Ok(posts);
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

        #region Get post by id
        [HttpGet("get-post-by-id/{postId}")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            try
            {
                var post = await _postService.GetPostByIdAsync(postId);
                return Ok(post);
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
