using Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IFavoriteService
    {
        Task<BaseResponseModel> GetFavoriteListByCustomerIdAsync(string customerId, int pageIndex, int pageSize);
        Task<BaseResponseModel> GetFavoriteListByIdAsync(int favoriteId);
    }
}
