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
	public class ServiceFeedbackRepository : GenericRepository<ServiceFeedback>, IServiceFeedbackRepository
	{
		public readonly ElderConnectionContext _context;
		public ServiceFeedbackRepository(ElderConnectionContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<ServiceFeedback>> GetFeedbackByServiceIdAsync(int serviceFeedbackId)
		{
			var query = _context.ServiceFeedbacks.Where(r => r.ServiceFeedbackId == serviceFeedbackId);
			return await query.ToListAsync();
		}
	}
}
