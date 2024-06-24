using Application.Common;
using Application.Library;
using Application.ResponseModels;
using Application.ViewModels.TransactionHistoryViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.IServices
{
    public interface ITransactionHistoryService
    {
        Task<BaseResponseModel> GetAllTransactionHistoryByAccountIdAsync(
            string id, int pageIndex = 0, int pageSize = 10);
        Task<BaseResponseModel> RequestTopUpWalletAsync(string accountId, float amount, HttpContext context);
        //Task<BaseResponseModel> RequestDepositToWallet(string accountId, int transId, Dictionary<string, StringValues> collections);
        Task<BaseResponseModel> RequestDepositToWallet_v2(VnPayModel vnPayModel);

        Task<bool> CreateTransasctionForService(string accountId, float amount);
    }
}
                                                                        