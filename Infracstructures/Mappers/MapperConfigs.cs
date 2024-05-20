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
        }

        partial void AccountMapperCongfigs();
    }
}
