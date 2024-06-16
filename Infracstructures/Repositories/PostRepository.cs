using Application.Common;
using Application.Helper;
using Application.IRepositories;
using Application.ViewModels.PostViewModels;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepostiory
    {

        public PostRepository(ElderConnectionContext context) : base(context)
        {

        }

        public async Task<Pagination<Post>> GetAllPostByCustomerIdAsync(
            string accountId, int pageIndex = 0, int pageSize = 10)
        {
            var query = _dbSet.Where(r => r.CustomerId == accountId)
                .Include(p => p.JobSchedule)
                .Include(p => p.Address)
                .OrderByDescending(r => r.CreateAt);
            return await ToListPaginationAsync(query, pageIndex, pageSize);
        }

        public async Task<Pagination<Post>> GetAllPostByStatusAsync(int status, int pageIndex = 0, int pageSize = 10)
        {
            var query = _dbSet.Where(r => r.PostStatus == status)
                .Include(p => p.JobSchedule)
                .Include(p => p.Address)
                .OrderByDescending(r => r.CreateAt);
            if (!query.Any())
            {
                return null;
            }
            return await ToListPaginationAsync(query, pageIndex, pageSize);
        }

        public async Task<Post?> GetPostByIdWithInclude(int id)
        {
            return await _dbSet.Where(p => p.PostId == id)
                .Include(p => p.JobSchedule)
                .ThenInclude(js => js.Connector)
                .Include(p => p.JobSchedule)
                .ThenInclude(js => js.Tasks)
                .Include(p => p.Address)
                .FirstOrDefaultAsync(); ;
        }
    }
}
