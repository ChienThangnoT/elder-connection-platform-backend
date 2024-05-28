﻿using Application;
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


            // Configure the local database connection
            services.AddDbContext<ElderConnectionContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("ElderConnectionDB"));
            });

            return services;
        }
    }
}
