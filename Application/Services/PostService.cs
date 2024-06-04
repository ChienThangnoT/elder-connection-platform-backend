﻿using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.JobScheduleViewModels;
using Application.ViewModels.PostViewModels;
using Application.ViewModels.TaskEDViewModels;
using AutoMapper;
using Domain.Enums.PostEnums;
using Domain.Enums.TaskEnums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJobScheduleService _jobScheduleService;
        private readonly ITaskEDService _taskEDService;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper, IJobScheduleService jobScheduleService, ITaskEDService taskEDService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jobScheduleService = jobScheduleService;
            _taskEDService = taskEDService;
        }

        #region Create Post Async
        public async Task<BaseResponseModel> CreatePostAsync(
            PostCreateViewModel postCreateViewModel,
            JobScheduleCreateViewModel jobScheduleCreateViewModel)
        {
            // Check if service, account, address exist
            var isExistService = await _unitOfWork.ServiceRepo.GetByIdAsync(postCreateViewModel.ServiceId)
                ?? throw new NotExistsException();
            var isExistAccount = await _unitOfWork.AccountRepo.GetAccountByIdAsync(postCreateViewModel.CustomerId)
                ?? throw new NotExistsException();
            var isExistAddress = await _unitOfWork.AddressRepo.GetByIdAsync(postCreateViewModel.AddressId)
                ?? throw new NotExistsException();
            //check if job schedule listDayWork is valid
            DateTime[] dates = jobScheduleCreateViewModel.ListDayWork
                .Split('|')
                .Where(part => !string.IsNullOrWhiteSpace(part))
                .Select(part => DateTime.TryParse(part, out var date) ? date : (DateTime?)null)
                .Where(date => date.HasValue)
                .Select(date => date.Value)
                .ToArray();
            if (dates.Length == 0)
                throw new InvalidDataException();
            string validListDayWork = string.Join("|", dates.Select(date => date.ToString("yyyy-MM-dd")));
            // Create job schedule
            jobScheduleCreateViewModel.ListDayWork = validListDayWork;
            jobScheduleCreateViewModel.LocationWork = isExistAddress.AddressDetail ?? string.Empty;
            var jobScheduleResult = await _jobScheduleService.CreateJobScheduleAsync(jobScheduleCreateViewModel);

            // Create post
            postCreateViewModel.JobScheduleId = jobScheduleResult.JobScheduleId;
            postCreateViewModel.PostStatus = (int)PostStatus.Posted;
            postCreateViewModel.Price = isExistService.FinalPrice;
            postCreateViewModel.SalaryAfterWork = postCreateViewModel.Price - (postCreateViewModel.Price * 0.1f);
            var post = _mapper.Map<Post>(postCreateViewModel);
            await _unitOfWork.PostRepo.AddAsync(post);
            await _unitOfWork.SaveChangesAsync();

            // Create task
            TaskEDCreateViewModel taskEDCreateViewModel;
            foreach (var date in dates)
            {
                taskEDCreateViewModel = new TaskEDCreateViewModel
                {
                    JobScheduleId = jobScheduleResult.JobScheduleId,
                    WorkDateAt = date,
                    TaskStatus = (int)TaskEDStatus.NotStarted,
                    CreateAt = DateTime.Now,
                    TaskUpdateAt = DateTime.Now
                };
                await _taskEDService.CreateTaskED(taskEDCreateViewModel);
            }

            var result = _mapper.Map<PostViewModel>(post);

            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Create post success",
                Result = result
            };
        }
        #endregion

        #region Delete Post Async
        public async Task<BaseResponseModel> DeletePostAsync(int postId)
        {
            // Check if post exist
            var post = await _unitOfWork.PostRepo.GetByIdAsync(postId) ?? throw new NotExistsException();

            //Get related job schedule and task
            var jobSchedule = await _unitOfWork.JobScheduleRepo.GetByIdAsync(post.JobScheduleId);
            var taskEDs = await _unitOfWork.TaskEDRepo.GetTaskEDListByJobScheduleIdAsync(jobSchedule.JobScheduleId);

            //Delete task
            foreach (var task in taskEDs)
            {
                _unitOfWork.TaskEDRepo.Remove(task);
            }
            //Delete job schedule
            _unitOfWork.JobScheduleRepo.Remove(jobSchedule);
            //Delete post
            _unitOfWork.PostRepo.Remove(post);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Remove post and all related fields success",
            };
        }
        #endregion

        #region Update Post Async
        public async Task<BaseResponseModel> UpdatePostAsync(
            int postId,
            PostUpdateViewModel postUpdateViewModel,
            JobScheduleUpdateViewModel jobScheduleUpdateViewModel)
        {
            // Check if post exist
            var post = await _unitOfWork.PostRepo
                .GetByIdAsync(postId)
                ?? throw new NotExistsException();

            // Check if the post has been claimed or not
            if (post.PostStatus != (int)PostStatus.Posted)
                throw new AlreadyClaimedException();

            // Check if service, address exist
            var isExistService = await _unitOfWork.ServiceRepo
                .GetByIdAsync(postUpdateViewModel.ServiceId)
                ?? throw new NotExistsException();
            var isExistAddress = await _unitOfWork.AddressRepo
                .GetByIdAsync(postUpdateViewModel.AddressId)
                ?? throw new NotExistsException();

            //check if job schedule listDayWork format is valid
            DateTime[] dates = jobScheduleUpdateViewModel.ListDayWork
                .Split('|')
                .Where(part => !string.IsNullOrWhiteSpace(part))
                .Select(part => DateTime.TryParse(part, out var date) ? date : (DateTime?)null)
                .Where(date => date.HasValue)
                .Select(date => date.Value)
                .ToArray();
            if (dates.Length == 0)
                throw new InvalidDataException();
            string validListDayWork = string.Join("|", dates.Select(date => date.ToString("yyyy-MM-dd")));
            // Update job schedule
            jobScheduleUpdateViewModel.LocationWork = isExistAddress.AddressDetail ?? string.Empty;
            jobScheduleUpdateViewModel.ListDayWork = validListDayWork;
            await _jobScheduleService.UpdateJobSchedule(post.JobScheduleId, jobScheduleUpdateViewModel);

            // Update post
            postUpdateViewModel.Price = isExistService.FinalPrice;
            postUpdateViewModel.SalaryAfterWork = postUpdateViewModel.Price - (postUpdateViewModel.Price * 0.1f);
            _mapper.Map(postUpdateViewModel, post);
            _unitOfWork.PostRepo.Update(post);
            await _unitOfWork.SaveChangesAsync();

            // Update task (drop old things and then add new)
            var taskEDs = await _unitOfWork.TaskEDRepo.GetTaskEDListByJobScheduleIdAsync(post.JobScheduleId);
            foreach (var taskED in taskEDs)
            {
                await _taskEDService.DeleteTaskED(taskED);
            }
            TaskEDCreateViewModel taskEDCreateViewModel;
            foreach (var date in dates)
            {
                taskEDCreateViewModel = new TaskEDCreateViewModel
                {
                    JobScheduleId = post.JobScheduleId,
                    WorkDateAt = date,
                    TaskStatus = (int)TaskEDStatus.NotStarted,
                    CreateAt = DateTime.Now,
                    TaskUpdateAt = DateTime.Now
                };
                await _taskEDService.CreateTaskED(taskEDCreateViewModel);
            }

            // Return result
            var result = _mapper.Map<PostViewModel>(post);
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Update post success",
                Result = result
            };
        }
        #endregion

        #region Get All Post By Customer Id Async
        public async Task<BaseResponseModel> GetAllPostByCustomerIdAsync(string id, int pageIndex = 0, int pageSize = 10)
        {
            // Check if account exist
            var isExistAccount = await _unitOfWork.AccountRepo.GetAccountByIdAsync(id)
                ?? throw new NotExistsException();
            // Get all post by customer id
            var posts = await _unitOfWork.PostRepo.GetAllPostByCustomerIdAsync(id, pageIndex, pageSize);
            // Map to view model
            var result = _mapper.Map<Pagination<PostViewModel>>(posts);

            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get all post by customer id success",
                Result = result
            };
        }
        #endregion

        #region Get Post List Pagination Async
        public async Task<Pagination<PostViewModel>> GetPostListPaginationAsync(int pageIndex = 0, int pageSize = 10)
        {
            if (pageIndex < 0)
            {
                string msg = "Page index cannot be less than 0. Input page index: " + pageIndex;
                throw new ArgumentException(msg);
            }

            if (pageSize <= 0)
            {
                string msg = "Page size cannot be less than 1. Input page size: " + pageSize;
                throw new ArgumentException(msg);
            }

            var posts =  await _unitOfWork.PostRepo.ToPaginationIncludeAsync(
                pageIndex, 
                pageSize,
                query => query.Include(p => p.JobSchedule)
                            .Include(p => p.Address).Include(p => p.Service));
            var result = _mapper.Map<Pagination<PostViewModel>>(posts);

            return result;
        }
        #endregion

        #region Get Post By Id Async
        public async Task<BaseResponseModel> GetPostByIdAsync(int postId)
        {
            var post = await _unitOfWork.PostRepo.GetPostByIdWithInclude(postId) ?? throw new NotExistsException();
            var result = _mapper.Map<PostViewModel>(post);
            return new SuccessResponseModel {
                Status = StatusCodes.Status200OK,
                Message = "Get post detail success",
                Result = result};
        }
        #endregion
    }
}