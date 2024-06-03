﻿using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.AddressViewModels;
using Application.ViewModels.SaleViewModels;
using AutoMapper;
using Domain.Models;
using Infracstructures.Mappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class SaleService : ISaleService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public SaleService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<BaseResponseModel> AddSaleAsync(SaleAddModel saleAddModel)
		{
			var sale = _mapper.Map<Sale>(saleAddModel);
			await _unitOfWork.SaleRepo.AddAsync(sale);
			await _unitOfWork.SaveChangesAsync();

			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status202Accepted,
				Message = "Sale added successfully",
				Result = saleAddModel
			};

			return response;
		}

		public async Task<BaseResponseModel> GetAllSaleAsync(int pageSize, int pageIndex)
		{
			var sales = await _unitOfWork.SaleRepo.GetAllSaleAsync(pageSize, pageIndex);
			var saleViewModels = _mapper.Map<Pagination<SaleViewModel>>(sales); 
			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Sales retrieved successfully",
				Result = saleViewModels
			};

			return response;
		}

		public async Task<BaseResponseModel> GetAccountAddressByAccountIdAsync(string accountId, int pageSize, int pageIndex)
		{
			var account = await _unitOfWork.AccountRepo.GetAccountByIdAsync(accountId) ?? throw new AccountAlreadyExistsException();
			var addressList = await _unitOfWork.AddressRepo.GetAccountAddressByAccountIdAsync(accountId, pageSize, pageIndex);

			var result = _mapper.Map<Pagination<AddressViewModel>>(addressList);

			return new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Get all account address success",
				Result = result
			};
		}

		public async Task<BaseResponseModel> GetSaleByIdAsync(int saleId)
		{
			var sale = await _unitOfWork.SaleRepo.GetByIdAsync(saleId);

			if (sale == null)
			{
				// If the sale with the specified ID doesn't exist, return an error response
				var errorResponse = new FailedResponseModel
				{
					Status = StatusCodes.Status404NotFound,
					Message = "Sale not found"
				};

				return errorResponse;
			}

			var saleViewModel = _mapper.Map<SaleViewModel>(sale);

			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Sale retrieved successfully",
				Result = saleViewModel
			};

			return response;
		}

		public async Task<BaseResponseModel> UpdateSaleAsync(int saleId, SaleUpdateModel saleUpdateModel)
		{
			var sale = await _unitOfWork.SaleRepo.GetByIdAsync(saleId);

			if (sale == null)
			{
				var errorResponse = new FailedResponseModel
				{
					Status = StatusCodes.Status404NotFound,
					Message = "Sale not found"
				};

				return errorResponse;
			}

			_mapper.Map(saleUpdateModel, sale);

			_unitOfWork.SaleRepo.Update(sale);
			await _unitOfWork.SaveChangesAsync();

			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Sale updated successfully",
				Result = sale
			};

			return response;
		}

		public async Task<BaseResponseModel> RemoveSaleAsync(int saleId)
		{
			var sale = await _unitOfWork.SaleRepo.GetByIdAsync(saleId);
			if (sale == null)
			{
				var errorResponse = new FailedResponseModel
				{
					Status = StatusCodes.Status404NotFound,
					Message = "Sale not found"
				};
				return errorResponse;
			}
			_unitOfWork.SaleRepo.Remove(sale);
			await _unitOfWork.SaveChangesAsync();
			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Sale removed successfully"
			};
			return response;
		}
	}
}
