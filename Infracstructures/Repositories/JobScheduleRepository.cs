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
    }
}
