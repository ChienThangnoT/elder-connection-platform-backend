using Application.Common;
using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
    public class TaskEDRepository : GenericRepository<TaskED>, ITaskEDRepository
    {
        public TaskEDRepository(ElderConnectionContext context) : base(context) { }

        public async Task<TaskED> GetTaskEDByIdWithInclude(int id)
        {
            return await _dbSet.Where(p => p.TaskId == id)
                .Include(p => p.Connector)
                .FirstOrDefaultAsync();
        }

        public async Task<Pagination<TaskED>> GetTaskEDListByConnectorIdAsync(
            string connectorId, int pageIndex = 0, int pageSize = 10)
        {
            var query = _dbSet.Where(r => r.ConnectorId == connectorId)
                .Include(t => t.Connector)
                .OrderByDescending(r => r.CreateAt);
            return await ToListPaginationAsync(query, pageIndex, pageSize);
        }

        public async Task<List<TaskED>> GetTaskEDListByJobScheduleIdAsync(int jobScheduleId)
        {
            return await _dbSet
                .Where(task => task.JobScheduleId == jobScheduleId)
                .ToListAsync();
        }
    }

}
