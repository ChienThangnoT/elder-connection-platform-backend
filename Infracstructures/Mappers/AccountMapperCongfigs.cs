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
        }
    }
}
