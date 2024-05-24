using Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepo { get; }
        public IAccountRepository AccountRepo { get; }
        public Task<int> SaveChangesAsync();
    }
}
