using Application.Common;
using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
    public class JobScheduleRepository : GenericRepository<JobSchedule>, IJobScheduleRepository
    {
        public JobScheduleRepository(ElderConnectionContext context) : base(context)
        {
        }

        public async Task<JobSchedule?> GetJobScheduleByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(js => js.JobScheduleId == id);
        }

        public async Task<JobSchedule?> GetJobScheduleByIdWithInclude(int id)
        {
            return await _dbSet.Where(js => js.JobScheduleId == id)
                .Include(js => js.Connector)
                .Include(js => js.Tasks)
                .FirstOrDefaultAsync();
        }

        public async Task<Pagination<JobSchedule>> GetJobScheduleListByConnectorIdAsync(
            string connectorId, int pageIndex = 0, int pageSize = 10)
        {
            var query = _dbSet.Where(js => js.ConnectorId == connectorId)
                .Include(js => js.Connector)
                .Include(js => js.Tasks)
                .OrderByDescending(js => js.JobScheduleId);
            return await ToListPaginationAsync(query, pageIndex, pageSize);
        }
    }
}
