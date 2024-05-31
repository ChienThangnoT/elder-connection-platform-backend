using Application.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface ITransactionHistoryRepository : IGenericRepository<TransactionHistory>
    {
        Task<Pagination<TransactionHistory>> GetTransactionHistoryByAccountIdAsync
            (string accountId, int pageIndex, int pageSize);
    }
}
