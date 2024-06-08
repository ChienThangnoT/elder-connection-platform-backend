using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.FavoriteListViewModels;
using Application.ViewModels.JobScheduleViewModels;
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
    public class FavoriteService : IFavoriteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FavoriteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> CreateConnectorToFavoriteListAsync(FavoriteListCreateViewModel favoriteListCreateViewModel)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                // Validate the customer and connector existence
                var isExistCustomer = await _unitOfWork.AccountRepo.GetAccountByIdAsync(favoriteListCreateViewModel.CustomerId);
                if (isExistCustomer == null)
                {
                    return new FailedResponseModel
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Customer not found."
                    };
                }

                var isExistConnector = await _unitOfWork.AccountRepo.GetAccountByIdAsync(favoriteListCreateViewModel.ConnectorId);
                if (isExistConnector == null)
                {
                    return new FailedResponseModel
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Connector not found."
                    };
                }

                var favoriteEntity = _mapper.Map<FavoriteList>(favoriteListCreateViewModel);
                await _unitOfWork.FavoriteRepo.AddAsync(favoriteEntity);
                await _unitOfWork.SaveChangesAsync();
                await transaction.CommitAsync();

                var result = _mapper.Map<FavoriteListCreateViewModel>(favoriteEntity);

                return new SuccessResponseModel
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Connector added to favorite list successfully.",
                    Result = result
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new FailedResponseModel
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = $"Error occurred: {ex.Message}"
                };
            }
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
