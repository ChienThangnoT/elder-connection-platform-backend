using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.AccountViewModels;
using Application.ViewModels.ServiceViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Pagination<DetailServiceViewModel>> GetAllServiceListPaginationAsync(int pageIndex = 0, int pageSize = 10)
        {
            if (pageIndex < 0)
            {
                string msg = "Page index cannot be less than 0. Input page index: " + pageIndex;
                throw new ArgumentException(msg);
            }

            if (pageSize <= 0)
            {
                string msg = "Page size cannot be less than 1. Input page size: " + pageSize;
                throw new ArgumentException(msg);
            }

            // get paginated account entities list
            var services = await _unitOfWork.ServiceRepo.ToPaginationIncludeAsync(
                pageIndex,
                pageSize,
                query => query.Include(s => s.ServiceType).Include(s => s.Sale)
            );


            var result = _mapper.Map<Pagination<DetailServiceViewModel>>(services);

            return result;
        }

        public async Task<BaseResponseModel> GetServiceById(int id)
        {
            var service = await _unitOfWork.ServiceRepo.GetByIdAsync(id) ?? throw new NotExistsException();
            var result =  _mapper.Map<ServiceViewModel>(service);
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get service success",
                Result = result
            };
        }
    }
}