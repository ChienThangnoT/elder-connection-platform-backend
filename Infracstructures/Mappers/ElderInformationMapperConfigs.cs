using Application.ViewModels.ElderInformationViewModels;
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
		partial void ElderInformationMapperConfigs()
		{
			CreateMap<ElderInformation, ElderInformationUpdateModel>().ReverseMap();
			CreateMap<ElderInformation, ElderInformationViewModel>()
				.ForMember(dest => dest.Name, otp => otp.MapFrom(src => src.Name))
				.ForMember(dest => dest.DateOfBirth, otp => otp.MapFrom(src => src.DateOfBirth))
				.ForMember(dest => dest.ProfilePicture, otp => otp.MapFrom(src => src.ProfilePicture))
				.ForMember(dest => dest.Sex, otp => otp.MapFrom(src => src.Sex))
				.ForMember(dest => dest.Pathology, otp => otp.MapFrom(src => src.Pathology))
				.ForMember(dest => dest.ChildId, otp => otp.MapFrom(src => src.ChildId))
				.ReverseMap();
		}
	}
}
