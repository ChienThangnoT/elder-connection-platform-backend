using Application.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IFavoriteRepository : IGenericRepository<FavoriteList>
    {
        Task<Pagination<FavoriteList>> GetFavoriteListByCustomerIdAsync(string customerId, int pageIndex, int pageSize);

        Task<FavoriteList?> GetFavoriteListByIdAsync(int favoriteId);

        Task<FavoriteList?> GetFavoriteListByIdWithInclude(int favoriteId);
    }
}
