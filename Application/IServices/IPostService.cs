using Application.ResponseModels;
using Application.ViewModels.JobScheduleViewModels;
using Application.ViewModels.PostViewModels;
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
    }
}
