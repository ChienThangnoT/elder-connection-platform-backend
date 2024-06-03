using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.JobScheduleViewModels;
using Application.ViewModels.PostViewModels;
using Application.ViewModels.TaskEDViewModels;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
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

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            // Create job schedule
            jobScheduleCreateViewModel.LocationWork = isExistAddress.AddressDetail ?? string.Empty;
            var jobSchedule = _mapper.Map<JobSchedule>(jobScheduleCreateViewModel);
            await _unitOfWork.JobScheduleRepo.AddAsync(jobSchedule);
            await _unitOfWork.SaveChangesAsync();
            var jobScheduleResult = _mapper.Map<JobScheduleViewModel>(jobSchedule);
          
            // Create post
            postCreateViewModel.JobScheduleId = jobScheduleResult.JobScheduleId;
            postCreateViewModel.SalaryAfterWork = postCreateViewModel.Price - (postCreateViewModel.Price * 0.1f);
            var post = _mapper.Map<Post>(postCreateViewModel);
            await _unitOfWork.PostRepo.AddAsync(post);
            await _unitOfWork.SaveChangesAsync();

            // Create task
            TaskEDCreateViewModel taskEDCreateViewModel;
            DateTime[] dates = jobScheduleCreateViewModel.ListDayWork.Split('|').Select(DateTime.Parse).ToArray();
            foreach (var date in dates)
            {
                taskEDCreateViewModel = new TaskEDCreateViewModel
                {
                    JobScheduleId = jobScheduleResult.JobScheduleId,
                    ConnectorId = postCreateViewModel.CustomerId,
                    WorkDateAt = date,
                    TaskStatus = 0,
                    CreateAt = DateTime.Now,
                    TaskUpdateAt = DateTime.Now,
                    TaskUpdateDescription = "Create task"
                };
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
    }
}
