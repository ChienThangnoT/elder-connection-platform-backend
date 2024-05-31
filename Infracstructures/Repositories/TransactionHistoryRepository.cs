using Application.Common;
using Application.IRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
    public class TransactionHistoryRepository : GenericRepository<TransactionHistory>, ITransactionHistoryRepository
    {
        public TransactionHistoryRepository(ElderConnectionContext context) : base(context)
        {
        }

        public async Task<Pagination<TransactionHistory>> GetTransactionHistoryByAccountIdAsync
            (string accountId, int pageIndex, int pageSize)
        {
            var query = _dbSet.Where(r => r.AccountId == accountId)
                .OrderByDescending(r => r.PaymentDate);
            return await ToListPaginationAsync(query, pageIndex, pageSize);
        }
    }
}


