using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.FavoriteListViewModels;
using Application.ViewModels.JobScheduleViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FavoriteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> GetFavoriteListByCustomerIdAsync(string customerId, int pageIndex, int pageSize)
        {
            var isExistCustomer = await _unitOfWork.AccountRepo.GetAccountByIdAsync(customerId) ?? throw new NotExistsException();
            var favoriteList = await _unitOfWork.FavoriteRepo.GetFavoriteListByCustomerIdAsync(customerId, pageIndex, pageSize);
            var result = _mapper.Map<Pagination<FavoriteDetailViewModel>>(favoriteList);
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get favorite list by customer id success",
                Result = result
            };
        }

        public async Task<BaseResponseModel> GetFavoriteListByIdAsync(int favoriteId)
        {
            var favorites = await _unitOfWork.FavoriteRepo.GetFavoriteListByIdWithInclude(favoriteId);
            var result = _mapper.Map<FavoriteDetailViewModel>(favorites);
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get favorite details successfully",
                Result = result
            };
        }
    }
}
