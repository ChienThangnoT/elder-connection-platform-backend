﻿using Application.Common;
using Application.ResponseModels;
using Application.ViewModels.JobScheduleViewModels;
using Application.ViewModels.PostViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IPostService
    {
        Task<BaseResponseModel> CreatePostAsync(
            PostCreateViewModel postCreateViewModel, 
            JobScheduleCreateViewModel jobScheduleCreateViewModel);
        Task<BaseResponseModel> DeletePostAsync(int postId);

        Task<BaseResponseModel> UpdatePostAsync(
            int postId,
            PostUpdateViewModel postUpdateViewModel,
            JobScheduleUpdateViewModel jobScheduleUpdateViewModel);

        Task<BaseResponseModel> GetAllPostByCustomerIdAsync(
            string id, int pageIndex = 0, int pageSize = 10);
        Task<BaseResponseModel> GetAllPostListByStatusPaginationAsync(int staus, int pageIndex = 0, int pageSize = 10);
        Task<BaseResponseModel> GetPostByIdAsync(int postId);
        Task<BaseResponseModel> ApplyPost(int postId, string connectorId);
        Task<BaseResponseModel> CheckIfPostIsexpired(int postId);
    }
}
