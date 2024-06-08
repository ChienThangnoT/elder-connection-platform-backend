using Application.Common;
using Application.ViewModels.PostViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IPostRepostiory: IGenericRepository<Post>
    {
        Task<Pagination<Post>> GetAllPostByCustomerIdAsync
            (string accountId, int pageIndex=0, int pageSize = 10);

        Task <Pagination<Post>> GetAllPostByStatusAsync 
            (int status, int pageIndex = 0, int pageSize = 10);

        Task<Post?> GetPostByIdWithInclude(int id);
    }
}
