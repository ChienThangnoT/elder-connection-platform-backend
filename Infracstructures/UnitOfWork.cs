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
        private readonly IServiceRepository _serviceRepository;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        private readonly IAddressRepository _addressRepository;

        public UnitOfWork(ElderConnectionContext context, 
            IAccountRepository accountRepository, 
            IUserRepository userRepository,
            IServiceRepository serviceRepository,
            IServiceTypeRepository serviceTypeRepository,
            IAddressRepository addressRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _userRepository = userRepository;
            _serviceRepository = serviceRepository;
            _serviceTypeRepository = serviceTypeRepository;
            _addressRepository = addressRepository;
        }

        public IUserRepository UserRepo => _userRepository;
        public IAccountRepository AccountRepo => _accountRepository;
        public IServiceRepository ServiceRepo => _serviceRepository;
        public IServiceTypeRepository ServiceTypeRepo => _serviceTypeRepository;
        public IAddressRepository AddressRepo => _addressRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
