using Application.ResponseModels;
using Application.ViewModels.ConnectorFeedbackViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface IConnectorFeedbackService
	{
		Task<BaseResponseModel> GetFeedbackViewModelAsync(string connectorId);
		Task<BaseResponseModel> GetFeedbackViewModelPaginationAsync(string connectorId, int pageIndex, int pageSize);
        Task<BaseResponseModel> RateConnectorAsync(RateConnectorViewModel rateConnectorViewModel);
    }
}
