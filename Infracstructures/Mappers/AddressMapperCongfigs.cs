using Application.ViewModels.AccountViewModels;
using Application.ViewModels.AddressViewModels;
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
        partial void AddressMapperCongfigs()
        {
            CreateMap<Address, AddressAddModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>()
                .ForMember(dest => dest.FirstName, otp => otp.MapFrom(src => src.Account != null ? src.Account.FirstName : string.Empty))
                .ForMember(dest => dest.LastName, otp => otp.MapFrom(src => src.Account != null ? src.Account.LastName : string.Empty))
                .ReverseMap();
        }
    }
}
