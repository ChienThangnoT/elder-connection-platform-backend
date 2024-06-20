﻿using Application;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.JobScheduleViewModels;
using Application.ViewModels.PostViewModels;
using Application.ViewModels.MultiRequestViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using Application.Exceptions;
using System.ComponentModel.DataAnnotations;

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
        [HttpGet("get-all-posts-by-status")]
        public async Task<IActionResult> GetAllPostsByStatus(int status, int pageIndex = 0, int pageSize = 10)
        {
            var posts = await _postService.GetAllPostListByStatusPaginationAsync(status, pageIndex, pageSize);

            return (posts == null) ? NotFound() : Ok(posts);

        }
        #endregion

        #region Get post by customer id
        [HttpGet("get-post-by-customer-id/{customerId}")]
        public async Task<IActionResult> GetPostByCustomerId(string customerId, int pageIndex = 0, int pageSize = 10)
        {
            var posts = await _postService.GetAllPostByCustomerIdAsync(customerId, pageIndex, pageSize);

            return posts == null
                ? throw new NotExistsException()
                : (IActionResult)Ok(posts);
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

        #region Apply post
        [HttpPost("apply-post/{postId}")]
        public async Task<IActionResult> ApplyPost(int postId, [Required] string connectorId)
        {
            try
            {
                var result = await _postService.ApplyPost(postId, connectorId);
                return (result == null)
                    ? NotFound()
                    : Ok(result);
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

        #region Check if post is expired
        [HttpGet("check-post-expired/{postId}")]
        public async Task<IActionResult> CheckPostExpired(int postId)
        {
            var result = await _postService.CheckIfPostIsexpired(postId);
            return (result == null)
                ? NotFound()
                : Ok(result);
        }
        #endregion
    }
}
