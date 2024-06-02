using Application.ResponseModels;
using Application.ViewModels.ConnectorInfoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IConnectorInfoService
    {
        public Task<BaseResponseModel> ApplyBecomConnectorAsync(string accountId, ApplyModel applyModel);

    }
}
