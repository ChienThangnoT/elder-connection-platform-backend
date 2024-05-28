using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.ServiceTypeViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponseModel> GetServiceTypeById(int serviceId)
        {
            var serviceType = await _unitOfWork.ServiceTypeRepo.GetByIdAsync(serviceId) ?? throw new NotExistsException();
            var result = _mapper.Map<DetailServiceTypeModel>(serviceType);
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get service type detail success",
                Result = result
            };
        }
    }
}
