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

        public async Task<int> CountTaskEDByJobScheduleIdAndStatusAsync(int jobScheduleId, int status)
        {
            return await _dbSet
                .Where(task => task.JobScheduleId == jobScheduleId && task.TaskStatus == status)
                .CountAsync();
        }

        public async Task<int> CountTotalTaskEDByJobScheduleIdAsync(int jobScheduleId)
        {
            return await _dbSet
                .Where(task => task.JobScheduleId == jobScheduleId)
                .CountAsync();
        }

        public async Task<List<DateTime?>> GetWorkDateListByJobScheduleIdAndStatusAsync(int jobScheduleId, int status)
        {
            return await _dbSet
            .Where(task => task.JobScheduleId == jobScheduleId && task.TaskStatus == status)
            .Select(task => task.WorkDateAt)
            .ToListAsync();
        }


        //Delete this method
        //public async Task<TaskED> GetTaskEDByIdAsync(int id)
        //{
        //    return await _dbSet.Where(p => p.TaskId == id)
        //        .FirstOrDefaultAsync();
        //}
        //public async Task<Pagination<TaskED>> GetTaskEDListByConnectorIdAsync(
        //    string connectorId, int pageIndex = 0, int pageSize = 10)
        //{
        //    var query = _dbSet
        //        .OrderByDescending(r => r.CreateAt);
        //    return await ToListPaginationAsync(query, pageIndex, pageSize);
        //}

        public async Task<List<TaskED>> GetTaskEDListByJobScheduleIdAsync(int jobScheduleId)
        {
            return await _dbSet
                .Where(task => task.JobScheduleId == jobScheduleId)
                .ToListAsync();
        }

        public async Task<Pagination<TaskED>> GetTaskEDListByJobScheduleIdAsync(
            int jobScheduleId, int pageIndex = 0, int pageSize = 10)
        {
            var query = _dbSet.Where(r => r.JobScheduleId == jobScheduleId)
                .OrderByDescending(r => r.CreateAt);
            if (!query.Any())
            {
                return null;
            }
            return await ToListPaginationAsync(query, pageIndex, pageSize);
        }
    }

}
