using Application.Common;
using Application.IRepositories;
using Application.ViewModels.AddressViewModels;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ElderConnectionContext context) : base(context)
        {
        }

        public async Task<Pagination<Address>> GetAccountAddressByAccountIdAsync(string accountId, int pageIndex, int pageSize)
        {
            var query = _dbSet.Where(r => r.AccountId == accountId);
            return await ToListPaginationAsync(query, pageIndex, pageSize);
        }
    }
}
