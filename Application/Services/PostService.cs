using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.JobScheduleViewModels;
using Application.ViewModels.PostViewModels;
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
            var jobSchedule = _mapper.Map<JobSchedule>(jobScheduleCreateViewModel);




            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Create post success",
                Result = null
            };
        }
        #endregion
    }
}
