using Application.ViewModels.JobScheduleViewModels;
using AutoMapper;
using Domain.Models;

namespace Infracstructures.Mappers
{
    public partial class MapperConfigs : Profile
    {
        partial void JobScheduleMapperConfigs()
        {
           CreateMap<JobSchedule, JobScheduleViewModel>().ReverseMap();
           CreateMap<JobSchedule, JobScheduleCreateViewModel>().ReverseMap();
        }
    }
}
