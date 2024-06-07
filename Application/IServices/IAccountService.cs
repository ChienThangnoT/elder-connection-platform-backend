using Application.Common;
using Application.IRepositories;
using Application.ResponseModels;
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
        Task<BaseResponseModel> GetUserDetailAsync(string id);
        Task<AccountDetailViewModel?> UpdateUserDetailASync(string id, AccountUpdateModel model);
        Task<BaseResponseModel> GetAccountByEmailAsync(string email);
        Task<Pagination<AccountDetailViewModel>> GetUserListPaginationAsync(int pageIndex = 0, int pageSize = 10);
        Task<BaseResponseModel> ActiveOrInactiveAccount(string id);
        Task<BaseResponseModel> GetUserWalletBalance(string accountId);
	}
}
