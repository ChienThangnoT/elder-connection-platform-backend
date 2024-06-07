using Application.ViewModels.TaskEDViewModels;
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
        partial void TaskEDMapperConfigs()
        {
            CreateMap<TaskED, TaskEDViewModel>().ReverseMap();
            CreateMap<TaskED, TaskEDCreateViewModel>().ReverseMap();
            CreateMap<TaskED, TaskEDUpdateViewModel>().ReverseMap();
        }
    }
}
