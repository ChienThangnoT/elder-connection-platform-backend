using Application.ViewModels.TrainingProgramViewModels;
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
		partial void TrainingProgramMapperConfigs()
		{
			CreateMap<TrainingProgram, TrainingProgramAddModel>().ReverseMap();
			CreateMap<TrainingProgram, TrainingProgramUpdateModel>().ReverseMap();
			CreateMap<TrainingProgram, TrainingProgramViewModel>()
				.ForMember(dest => dest.TraningProgramId, otp => otp.MapFrom(src => src.TraningProgramId))
				.ForMember(dest => dest.TraningProgramLevel, otp => otp.MapFrom(src => src.TraningProgramLevel))
				.ForMember(dest => dest.TraningProgramTitle, otp => otp.MapFrom(src => src.TraningProgramTitle))
				.ForMember(dest => dest.TraningProgramContent, otp => otp.MapFrom(src => src.TraningProgramContent))
				.ForMember(dest => dest.TraningProgramDuration, otp => otp.MapFrom(src => src.TraningProgramDuration))
				.ForMember(dest => dest.Status, otp => otp.MapFrom(src => src.Status))
				.ReverseMap();
		}
	}
}
