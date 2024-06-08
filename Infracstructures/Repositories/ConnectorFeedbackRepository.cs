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
	public class ConnectorFeedbackRepository : GenericRepository<ConnectorFeedback>, IConnectorFeedbackRepository
	{
		private readonly ElderConnectionContext _context;
		public ConnectorFeedbackRepository(ElderConnectionContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<ConnectorFeedback>> GetFeedbackByConnectorIdAsync(string connectorId)
		{
			var query = _context.ConnectorFeedbacks.Where(r => r.ConnectorId == connectorId);
			return await query.ToListAsync();
		}

		public async Task<Pagination<ConnectorFeedback>> GetFeedbackByConnectorIdPaginationAsync(string connectorId, int pageIndex, int pageSize)
		{
			var query = _context.ConnectorFeedbacks.Where(r => r.ConnectorId == connectorId);
			if (!query.Any())
			{
				return null;
			}
			return await ToListPaginationAsync(query, pageIndex, pageSize);
		}
	}
}
