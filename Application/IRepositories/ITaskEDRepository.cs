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
        Task<Pagination<TaskED>> GetTaskEDListByConnectorIdAsync(
            string connectorId, int pageIndex = 0, int pageSize = 10);
        Task<TaskED> GetTaskEDByIdWithInclude(int id);
    }
}
