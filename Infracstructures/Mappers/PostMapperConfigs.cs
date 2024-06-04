using Application.ViewModels.PostViewModels;
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
        partial void PostMapperConfigs()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.serviceName, otp => otp.MapFrom(src => src.Service != null ? src.Service.ServiceName : string.Empty))
                .ForMember(dest => dest.customerFirstName, otp => otp.MapFrom(src => src.Customer != null ? src.Customer.FirstName : string.Empty))
                .ForMember(dest => dest.customerLastName, otp => otp.MapFrom(src => src.Customer != null ? src.Customer.LastName : string.Empty))
                .ReverseMap();
            CreateMap<Post, PostCreateViewModel>().ReverseMap();
            CreateMap<Post, PostUpdateViewModel>().ReverseMap();
        }
    }
}
