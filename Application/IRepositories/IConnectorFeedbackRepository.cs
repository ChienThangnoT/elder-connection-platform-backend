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
		Task<Pagination<ConnectorFeedback>> GetFeedbackByConnectorIdAsync(string connectorId, int pageIndex, int pageSize);
	}
}
