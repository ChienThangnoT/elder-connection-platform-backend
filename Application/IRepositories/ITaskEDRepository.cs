using Application.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface ITaskEDRepository : IGenericRepository<TaskED>
    {
        Task<List<TaskED>> GetTaskEDListByJobScheduleIdAsync(int jobScheduleId);
        //Delete this method
        //Task<Pagination<TaskED>> GetTaskEDListByConnectorIdAsync(
        //    string connectorId, int pageIndex = 0, int pageSize = 10);
        //Task<TaskED> GetTaskEDByIdAsync(int id);
        Task<Pagination<TaskED>> GetTaskEDListByJobScheduleIdAsync(
            int jobScheduleId, int pageIndex = 0, int pageSize = 10) ;

        Task<int> CountTotalTaskEDByJobScheduleIdAsync(int jobScheduleId);

        Task<int> CountTaskEDByJobScheduleIdAndStatusAsync(int jobScheduleId, int status);

        Task<List<DateTime?>> GetWorkDateListByJobScheduleIdAndStatusAsync(int jobScheduleId, int status);
    }
}
