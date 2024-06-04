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
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;
        private readonly IPostRepostiory _postRepostiory;
        private readonly IJobScheduleRepository _jobScheduleRepository;
        private readonly IConnectorInfoRepository _connectorInfoRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly ITaskEDRepository _taskEDRepository;

		public UnitOfWork(ElderConnectionContext context,
            IAccountRepository accountRepository, 
            IUserRepository userRepository,
            IServiceRepository serviceRepository,
            IServiceTypeRepository serviceTypeRepository,
            IAddressRepository addressRepository,
            ITransactionHistoryRepository transactionHistoryRepository,
            IPostRepostiory postRepostiory,
            IJobScheduleRepository jobScheduleRepository,
            IConnectorInfoRepository connectorInfoRepository, 
            ISaleRepository saleRepository,
            ITaskEDRepository taskEDRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _userRepository = userRepository;
            _serviceRepository = serviceRepository;
            _serviceTypeRepository = serviceTypeRepository;
            _addressRepository = addressRepository;
            _transactionHistoryRepository = transactionHistoryRepository;
            _connectorInfoRepository = connectorInfoRepository;
			_saleRepository = saleRepository;		
            _postRepostiory = postRepostiory;
            _jobScheduleRepository = jobScheduleRepository;
            _taskEDRepository = taskEDRepository;
        }

        public IUserRepository UserRepo => _userRepository;
        public IAccountRepository AccountRepo => _accountRepository;
        public IServiceRepository ServiceRepo => _serviceRepository;
        public IServiceTypeRepository ServiceTypeRepo => _serviceTypeRepository;
        public IAddressRepository AddressRepo => _addressRepository;
        public ITransactionHistoryRepository TransactionHistoryRepo => _transactionHistoryRepository;
        public IPostRepostiory PostRepo => _postRepostiory;
        public IJobScheduleRepository JobScheduleRepo => _jobScheduleRepository;
        public IConnectorInfoRepository ConnectorInfoRepo => _connectorInfoRepository;
		public ISaleRepository SaleRepo => _saleRepository;
        public ITaskEDRepository TaskEDRepo => _taskEDRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
