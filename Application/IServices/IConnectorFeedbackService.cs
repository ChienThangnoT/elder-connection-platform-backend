using Application.ResponseModels;
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
	}
}
