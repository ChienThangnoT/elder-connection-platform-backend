using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.ConnectorInfoViewModels;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
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

        public async Task<BaseResponseModel> ApplyBecomConnectorAsync(string accountId, ApplyModel applyModel)
        {
            var mapModel = _mapper.Map<ConnectorInfo>(applyModel);
            await _unitOfWork.ConnectorInfoRepo.AddAsync(mapModel);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<ApplyModel>(mapModel);
            var connectorId = result.ConnectorInforId;
            var account = await _unitOfWork.AccountRepo.GetAccountByIdAsync(accountId);
            account.ConnectorInforId = connectorId;
            _unitOfWork.AccountRepo.Update(account);
            
            return new SuccessResponseModel { 
                Status = StatusCodes.Status201Created, 
                Message = "Apply become connector success!", 
                Result = result 
            };
        }
    }
}
