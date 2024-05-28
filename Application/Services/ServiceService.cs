using Application.Common;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.AccountViewModels;
using Application.ViewModels.ServiceViewModels;
using AutoMapper;
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
        private readonly IServiceTypeService _serviceTypeService;

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper, IServiceTypeService serviceTypeService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceTypeService = serviceTypeService;
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
    }
}