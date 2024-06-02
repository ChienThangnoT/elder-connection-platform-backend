using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.ConnectorInfoViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ConnectorInfoService : IConnectorInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConnectorInfoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<BaseResponseModel> ApplyBecomConnectorAsync(string accountId, ApplyModel applyModel)
        {
            throw new NotImplementedException();
        }
        //public Task<BaseResponseModel> ApplyBecomConnectorAsync(string accountId, ApplyModel applyModel)
        //{
        //    _unitOfWork
        //}
    }
}
