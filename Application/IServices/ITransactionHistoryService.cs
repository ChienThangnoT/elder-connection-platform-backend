using Application.Common;
using Application.ResponseModels;
using Application.ViewModels.TransactionHistoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITransactionHistoryService
    {
        Task<BaseResponseModel> GetAllTransactionHistoryByAccountIdAsync(
            string id, int pageIndex = 0, int pageSize = 10);
    }
}
