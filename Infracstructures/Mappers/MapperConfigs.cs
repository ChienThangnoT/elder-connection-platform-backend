using Application.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Mappers
{
    public partial class MapperConfigs : Profile 
    {
        public MapperConfigs()
        {
            //add map here

            //create map between pagination
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            //add account mapper configs
            AccountMapperCongfigs();

            //add service mapper configs
            ServiceMapperCongfigs();

            //add service type mapper configs
            ServiceTypeMapperCongfigs();

            //add address mapper configs
            AddressMapperCongfigs();

            //add transaction history mapper configs
            TransactionHistoryMapperConfigs();
        }

        partial void AccountMapperCongfigs();
        partial void ServiceMapperCongfigs();
        partial void ServiceTypeMapperCongfigs();
        partial void AddressMapperCongfigs();
        partial void TransactionHistoryMapperConfigs();
    }
}
