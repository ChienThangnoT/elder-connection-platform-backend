using Application.ViewModels.AccountViewModels;
using Application.ViewModels.TransactionHistoryViewModels;
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
        partial void TransactionHistoryMapperConfigs()
        {
            CreateMap<TransactionHistory, TransactionHistoryViewModel>().ReverseMap();
            CreateMap<TransactionHistory, TransactionModel>().ReverseMap();
        }
    }
}
