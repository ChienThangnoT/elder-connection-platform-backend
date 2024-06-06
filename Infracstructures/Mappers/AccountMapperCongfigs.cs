using Application.ViewModels.AccountViewModels;
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
		partial void AccountMapperCongfigs()
		{
			CreateMap<Account, AccountDetailViewModel>().ReverseMap();
			CreateMap<AccountUpdateModel, Account>().ReverseMap();
			CreateMap<ConnectorSignUpModel, Account>().ReverseMap();
			CreateMap<Account, WalletBalanceViewModel>()
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
				.ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture))
				.ForMember(dest => dest.WalletBalance, opt => opt.MapFrom(src => src.WalletBalance))
				.ReverseMap();
		}
	}
}
