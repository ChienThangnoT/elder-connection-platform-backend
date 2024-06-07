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

            //add post mapper configs
            PostMapperConfigs();

            //add job schedule mapper configs
            JobScheduleMapperConfigs();

            //add task ed mapper configs
            TaskEDMapperConfigs();
        
            //add connector info mapper configs
            ConnectorInfoCongfigs();

			//add sale mapper configs
			SaleMapperConfigs();

			//add connector feedback mapper configs
            ConnectorFeedbackMapperConfigs();

			//add service feedback mapper configs
			ServiceFeedbackMapperConfigs();

			//add training program mapper configs
            TrainingProgramMapperConfigs();

            //add favorite list mapper configs
            FavoriteMapperCongfigs();
        }

        partial void AccountMapperCongfigs();
        partial void ServiceMapperCongfigs();
        partial void ServiceTypeMapperCongfigs();
        partial void AddressMapperCongfigs();
        partial void ConnectorInfoCongfigs();
        partial void TransactionHistoryMapperConfigs();
        partial void PostMapperConfigs();
        partial void JobScheduleMapperConfigs();
        partial void TaskEDMapperConfigs();
		partial void SaleMapperConfigs();
		partial void ServiceFeedbackMapperConfigs();
		partial void TrainingProgramMapperConfigs();

		partial void ConnectorFeedbackMapperConfigs();
        partial void FavoriteMapperCongfigs();
    }
}
