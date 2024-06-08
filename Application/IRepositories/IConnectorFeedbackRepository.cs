using Application.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
	public interface IConnectorFeedbackRepository : IGenericRepository<ConnectorFeedback>
	{
		Task<List<ConnectorFeedback>> GetFeedbackByConnectorIdAsync(string connectorId);
		Task<Pagination<ConnectorFeedback>> GetFeedbackByConnectorIdPaginationAsync(string connectorId, int pageIndex, int pageSize);
        Task<bool> ExistsFeedbackAsync(int taskId, string customerId, string connectorId);
    }
}
