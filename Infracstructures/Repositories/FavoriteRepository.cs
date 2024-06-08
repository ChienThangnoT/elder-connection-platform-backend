using Application.Common;
using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
    public class FavoriteRepository : GenericRepository<FavoriteList>, IFavoriteRepository
    {
        public FavoriteRepository(ElderConnectionContext context) : base(context)
        {
        }

        public async Task<Pagination<FavoriteList>> GetFavoriteListByCustomerIdAsync(string customerId, int pageIndex, int pageSize)
        {
            var query = _dbSet.Where(fl => fl.CustomerId == customerId)
                .Include(fl => fl.Customer)
                .OrderBy(fl => fl.FavoriteListId);
            return await ToListPaginationAsync(query, pageIndex, pageSize);
        }

        public async Task<FavoriteList?> GetFavoriteListByIdAsync(int favoriteId)
        {
            return await _dbSet.FirstOrDefaultAsync(fl => fl.FavoriteListId == favoriteId);
        }

        public async Task<FavoriteList?> GetFavoriteListByIdWithInclude(int favoriteId)
        {
            return await _dbSet.Where(fl => fl.FavoriteListId == favoriteId)
                .Include(fl => fl.Customer)
                .FirstOrDefaultAsync();
        }
    }
}
