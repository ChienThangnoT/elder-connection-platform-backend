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
		public AccountRepository(ElderConnectionContext context) : base(context)
		{
		}

		public async Task<Account> GetAccountByEmailAsync(string email)
		{
			return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
		}
		#region GetByIdAsyncIncludeRole
		public async Task<Account?> GetAccountByIdAsync(string id)
		{
			return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
		}
		#endregion

		//#region GetWalletBalance
		//public async Task<Account> GetWalletBalance(string accountId)
		//{
		//	return await _dbSet.FirstOrDefaultAsync(x => x.Id == accountId);
		//}
		//#endregion
	}
}
