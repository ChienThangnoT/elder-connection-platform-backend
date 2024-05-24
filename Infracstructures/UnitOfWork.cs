using Application;
using Application.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ElderConnectionContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(ElderConnectionContext context, IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _userRepository = userRepository;
        }

        public IUserRepository UserRepo => _userRepository;

        public IAccountRepository AccountRepo => _accountRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
