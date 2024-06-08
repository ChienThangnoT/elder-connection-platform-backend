using Application.ViewModels.FavoriteListViewModels;
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
        partial void FavoriteMapperCongfigs()
        {
            CreateMap<FavoriteList, FavoriteDetailViewModel>()
                .ForMember(dest => dest.connectorFirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.connectorLastName, opt => opt.MapFrom(src => src.Customer.LastName))
                .ForMember(dest => dest.connectorBiography, opt => opt.MapFrom(src => src.Customer.Biography))
                .ForMember(dest => dest.connectorSex, opt => opt.MapFrom(src => src.Customer.Sex))
                .ForMember(dest => dest.connectorEmail, opt => opt.MapFrom(src => src.Customer.Email))
                .ForMember(dest => dest.connectorAvarageRating, opt => opt.MapFrom(src => src.Customer.AvgRating))
                .ForMember(dest => dest.connectorPhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.connectorIdentityNumber, opt => opt.MapFrom(src => src.Customer.CccdNumber))
                .ReverseMap();

            CreateMap<FavoriteList, FavoriteListCreateViewModel>().ReverseMap();
        }
    }
}
