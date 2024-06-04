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
        private readonly IConnectorInfoRepository _connectorInfoRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IConnectorFeedbackRepository _connectorFeedbackRepository;
        private readonly IServiceFeedbackRepository _serviceFeedbackRepository;
        private readonly ITrainingProgramRepository _trainingProgramRepository;

		public UnitOfWork(ElderConnectionContext context,
            IAccountRepository accountRepository, 
            IUserRepository userRepository,
            IServiceRepository serviceRepository,
            IServiceTypeRepository serviceTypeRepository,
            IAddressRepository addressRepository,
            ITransactionHistoryRepository transactionHistoryRepository,
            IConnectorInfoRepository connectorInfoRepository, 
            ISaleRepository saleRepository, 
            IConnectorFeedbackRepository connectorFeedbackRepository,
            IServiceFeedbackRepository serviceFeedbackRepository,
            ITrainingProgramRepository trainingProgramRepository)
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
			_connectorFeedbackRepository = connectorFeedbackRepository;
            _serviceFeedbackRepository = serviceFeedbackRepository;
			_trainingProgramRepository = trainingProgramRepository;
		}

        public IUserRepository UserRepo => _userRepository;
        public IAccountRepository AccountRepo => _accountRepository;
        public IServiceRepository ServiceRepo => _serviceRepository;
        public IServiceTypeRepository ServiceTypeRepo => _serviceTypeRepository;
        public IAddressRepository AddressRepo => _addressRepository;
        public ITransactionHistoryRepository TransactionHistoryRepo => _transactionHistoryRepository;
        public IConnectorInfoRepository ConnectorInfoRepo => _connectorInfoRepository;
		public ISaleRepository SaleRepo => _saleRepository;
		public IConnectorFeedbackRepository ConnectorFeedbackRepo => _connectorFeedbackRepository;
        public IServiceFeedbackRepository ServiceFeedbackRepo => _serviceFeedbackRepository;
		public ITrainingProgramRepository TrainingProgramRepo => _trainingProgramRepository;

		public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
