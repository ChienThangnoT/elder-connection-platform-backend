using Application.ResponseModels;
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

        Task<IEnumerable<BaseResponseModel>> GetAllJobSchedulesAsync();
        Task<BaseResponseModel> GetAllJobScheduleAsync(int pageIndex, int pageSize);

        Task<BaseResponseModel> GetJobScheduleByIdAsync(int id);

        Task<BaseResponseModel> GetJobScheduleByConnectorIdAsync(
            string connectorId, int pageIndex = 0, int pageSize = 10);

        Task CalculateJobScheduleProgress(int jobScheduleId);

        Task<BaseResponseModel> GetJobScheduleProcessAsync(int jobScheduleId);
    }
}
