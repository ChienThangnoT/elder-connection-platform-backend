using Application.Common;
using Application.ResponseModels;
using Application.ViewModels.AccountViewModels;
using Application.ViewModels.ServiceViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IServiceService
    {
        Task<Pagination<DetailServiceViewModel>> GetAllServiceListPaginationAsync(int pageIndex = 0, int pageSize = 10);
        Task<BaseResponseModel> GetServiceById(int id);
    }
}
