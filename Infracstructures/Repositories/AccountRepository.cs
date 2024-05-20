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
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(ElderConnectionContext context ) : base(context)
        {
        }
        #region GetByIdAsyncIncludeRole
        public async Task<Account?> GetAccountByIdAsync(string id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion
    }
}
