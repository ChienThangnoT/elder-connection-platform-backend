using Application.ViewModels.ServiceTypeViewModels;
using Application.ViewModels.ServiceViewModels;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Mappers
{
    public partial class MapperConfigs : Profile
    {
        partial void ServiceTypeMapperCongfigs()
        {
            CreateMap<ServiceType, DetailServiceTypeModel>().ReverseMap();
        }
    }
}
