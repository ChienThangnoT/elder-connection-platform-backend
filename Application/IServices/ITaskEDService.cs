using Application.Common;
using Application.ResponseModels;
using Application.ViewModels.TaskEDViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITaskEDService
    {
        Task CreateTaskED(TaskEDCreateViewModel taskEDCreateViewModel);
        Task DeleteTaskED(TaskED taskED);
        Task<BaseResponseModel> GetTaskEDListByConnectorIdAsync(
            string connector, int pageIndex = 0, int pageSize = 10);
        Task<BaseResponseModel> GetTaskEDByIdAsync(int taskEDId);
        Task<BaseResponseModel> GetTaskEDListByJobScheduleIdAsync(
            int jobScheduleId, int pageIndex = 0, int pageSize = 10);

        Task<BaseResponseModel> UpdateTaskEDStatus(int id, TaskEDUpdateViewModel taskUpdateViewModel);
    }
}
