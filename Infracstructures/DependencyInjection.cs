using Application;
using Application.IRepositories;
using Application.IServices;
using Application.Services;
using Infracstructures.Mappers;
using Infracstructures.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infracstructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfractstructure(this IServiceCollection services, IConfiguration config)
        {
            // Configure UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Configure AutoMapper
            services.AddAutoMapper(typeof(MapperConfigs).Assembly);

            // Configure Account services and repositories
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountService, AccountService>();

            // Configure Adress services and repositories
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IAddressService, AddressService>();
            
            // Configure Account services and repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            
            // Configure Service services and repositories
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IServiceService, ServiceService>(); 

            // Configure ServiceType services and repositories
            services.AddTransient<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddTransient<IServiceTypeService, ServiceTypeService>();

            // Configure TransactionHistory services and repositories
            services.AddTransient<ITransactionHistoryRepository, TransactionHistoryRepository>();
            services.AddTransient<ITransactionHistoryService, TransactionHistoryService>();

            // Configure Post services and repositories
            services.AddTransient<IPostRepostiory, PostRepository>();
            services.AddTransient<IPostService, PostService>();

            // Configure JobSchedule services and repositories
            services.AddTransient<IJobScheduleRepository, JobScheduleRepository>();
            services.AddTransient<IJobScheduleService, JobScheduleService>();

            // Configure ConnectorInfo services and repositories
            services.AddTransient<IConnectorInfoRepository, ConnectorInfoRepository>();
            services.AddTransient<IConnectorInfoService, ConnectorInfoService>();

			// Configure Sale services and repositories
			services.AddTransient<ISaleRepository, SaleRepository>();
			services.AddTransient<ISaleService, SaleService>();

			// Configure the local database connection
			services.AddDbContext<ElderConnectionContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("ElderConnectionDB"));
            });

            return services;
        }
    }
}
