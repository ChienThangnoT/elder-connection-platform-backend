using Application.ViewModels.JobScheduleViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IJobScheduleService
    {
        Task<JobScheduleViewModel> CreateJobScheduleAsync(
            JobScheduleCreateViewModel jobScheduleCreateViewModel);

        Task UpdateJobSchedule(
            int jobScheduleId,
            JobScheduleUpdateViewModel jobScheduleUpdateViewModel);

        Task DeleteJobSchedule(JobSchedule jobSchedule);
    }
}
