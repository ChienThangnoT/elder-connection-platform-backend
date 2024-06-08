using Application.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;
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
        public IServiceRepository ServiceRepo { get; }
        public IServiceTypeRepository ServiceTypeRepo { get; }
        public IAddressRepository AddressRepo { get; }
        public ITransactionHistoryRepository TransactionHistoryRepo { get; }    
        public IConnectorInfoRepository ConnectorInfoRepo { get; }
		public ISaleRepository SaleRepo { get; }
        public IPostRepostiory PostRepo { get; }
        public IJobScheduleRepository JobScheduleRepo { get; }
        public ITaskEDRepository TaskEDRepo { get; }
		public IConnectorFeedbackRepository ConnectorFeedbackRepo { get; }
		public IServiceFeedbackRepository ServiceFeedbackRepo { get; }
		public ITrainingProgramRepository TrainingProgramRepo { get; }
        public IFavoriteRepository FavoriteRepo { get; }
        public IElderInformationRepository ElderInformationRepo { get; }
		public Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
