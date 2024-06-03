using Application.ViewModels.AddressViewModels;
using Application.ViewModels.SaleViewModels;
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
		partial void SaleMapperConfigs()
		{
			CreateMap<Sale, SaleAddModel>().ReverseMap();
			CreateMap<Sale, SaleUpdateModel>().ReverseMap();
			CreateMap<Sale, SaleViewModel>()
				.ForMember(dest => dest.SaleName, otp => otp.MapFrom(src => src.SaleName))
				.ForMember(dest => dest.SaleDescription, otp => otp.MapFrom(src => src.SaleDescription))
				.ForMember(dest => dest.SalePercent, otp => otp.MapFrom(src => src.SalePercent))
				.ReverseMap();
		}
	}
}
