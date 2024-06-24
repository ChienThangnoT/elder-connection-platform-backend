using Application.Common;
using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infracstructures.Repositories
{
    public class JobScheduleRepository : GenericRepository<JobSchedule>, IJobScheduleRepository
    {
        private readonly ElderConnectionContext _context;
        public JobScheduleRepository(ElderConnectionContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pagination<JobSchedule>> GetAllJobScheduleAsync(int pageIndex, int pageSize)
        {
            var query = _context.JobSchedules.AsQueryable();
            return await ToListPaginationAsync(query, pageIndex, pageSize);
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

        public async Task<List<JobSchedule>> GetJobScheduleListByConnectorId(string connectorId)
        {
            return await _dbSet
            .Where(task => task.ConnectorId == connectorId )
            .ToListAsync();
        }

        public async Task<Pagination<JobSchedule>> GetJobScheduleListByConnectorIdAsync(
            string connectorId, int pageIndex = 0, int pageSize = 10)
        {
            var query = _dbSet.Where(js => js.ConnectorId == connectorId)
                .Include(js => js.Connector)
                .Include(js => js.Tasks)
                .OrderByDescending(js => js.JobScheduleId);
            if (!query.Any())
            {
                return null;
            }
            return await ToListPaginationAsync(query, pageIndex, pageSize);
        }

        public async Task<List<DateTime?>> GetWorkDateListByConnectorIdAndStatusAsync(string connectorId, int status)
        {
            var jobSchedules = await _dbSet
            .Where(js => js.ConnectorId == connectorId && js.TaskProcess < 100)
            .Include(js => js.Tasks)
            .ToListAsync();

            if (!jobSchedules.Any())
            {
                return null;
            }
            var workDates = jobSchedules
                .SelectMany(js => js.Tasks)
                .Where(task => task.TaskStatus < status)
                .Select(task => task.WorkDateAt)
                .ToList();
            if (!workDates.Any())
            {
                return null;
            }
            return workDates;
        }
    }
}
