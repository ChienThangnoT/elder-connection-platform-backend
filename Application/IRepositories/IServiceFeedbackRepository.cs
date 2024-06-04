using Application.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
	public interface IServiceFeedbackRepository : IGenericRepository<ServiceFeedback>
	{
		Task<Pagination<ServiceFeedback>> GetFeedbackByServiceIdAsync(int serviceFeedbackId, int pageSize, int pageIndex);
	}
}
