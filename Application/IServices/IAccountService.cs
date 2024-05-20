using Application.IRepositories;
using Application.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAccountService 
    {
        Task<AccountDetailViewModel?> GetUserDetailAsync(string id);
    }
}
