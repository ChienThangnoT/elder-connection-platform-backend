using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> GetAccountByIdAsync(string id);
    }
}
