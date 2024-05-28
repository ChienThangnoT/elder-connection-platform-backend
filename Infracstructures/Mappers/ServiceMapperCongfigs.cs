using Application.ViewModels.AccountViewModels;
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
        partial void ServiceMapperCongfigs()
        {
            CreateMap<Service, DetailServiceViewModel>()
                .ForMember(dest => dest.ServiceTypeName, opt => opt.MapFrom(src => src.ServiceType != null ? src.ServiceType.ServiceTypeName : string.Empty))
                .ForMember(dest => dest.SaleName, opt => opt.MapFrom(src => src.Sale != null ? src.Sale.SaleName : string.Empty))
                .ReverseMap();
        }
    }
}
