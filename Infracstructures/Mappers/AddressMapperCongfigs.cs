﻿using Application.ViewModels.AccountViewModels;
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
            CreateMap<Address, AddressUpdateModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
        }
    }
}
