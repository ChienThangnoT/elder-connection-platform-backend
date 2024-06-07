using Application.ViewModels.JobScheduleViewModels;
using AutoMapper;
using Domain.Models;

namespace Infracstructures.Mappers
{
    public partial class MapperConfigs : Profile
    {
        partial void JobScheduleMapperConfigs()
        {
            CreateMap<JobSchedule, JobScheduleViewModel>()
                .ForMember(dest => dest.connectorFirstName, opt => opt.MapFrom(src => src.Connector.FirstName))
                .ForMember(dest => dest.connectorLastName, opt => opt.MapFrom(src => src.Connector.LastName))
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
                .ReverseMap();
            CreateMap<JobSchedule, JobScheduleCreateViewModel>().ReverseMap();
            CreateMap<JobSchedule, JobScheduleUpdateViewModel>().ReverseMap();
        }
    }
}
