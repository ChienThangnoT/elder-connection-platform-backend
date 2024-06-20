using Application.Common;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IJobScheduleRepository : IGenericRepository<JobSchedule>
    {
        Task<JobSchedule?> GetJobScheduleByIdAsync(int id);
        Task<Pagination<JobSchedule>> GetAllJobScheduleAsync(int pageIndex, int pageSize);
        Task<JobSchedule?> GetJobScheduleByIdWithInclude(int id);
        Task<Pagination<JobSchedule>> GetJobScheduleListByConnectorIdAsync(
            string connectorId, int pageIndex = 0, int pageSize = 10);
        Task<List<JobSchedule>> GetJobScheduleListByConnectorId(string connectorId);

        Task<List<DateTime?>> GetWorkDateListByConnectorIdAndStatusAsync(string connectorId, int status);
    }
}
