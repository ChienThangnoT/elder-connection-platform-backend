using Application.IRepositories;
using Domain.Models;
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
    }
}
