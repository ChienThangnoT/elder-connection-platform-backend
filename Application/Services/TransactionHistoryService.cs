using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.TransactionHistoryViewModels;
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
    public class TransactionHistoryService : ITransactionHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Get Transaction History By Account Id 
        public async Task<BaseResponseModel> GetAllTransactionHistoryByAccountIdAsync
            (string id, int pageIndex = 0, int pageSize = 10)
        {
            var exsitedUser = await _unitOfWork.AccountRepo.GetAccountByIdAsync(id) 
                ?? throw new NotExistsException();

            var transactionHistoryList = await _unitOfWork.TransactionHistoryRepo.
                GetTransactionHistoryByAccountIdAsync(id,pageIndex,pageSize);

            var result = _mapper.Map<Pagination<TransactionHistoryViewModel>>(transactionHistoryList);

            var item = result.Items;

            if (item.Count == 0)
            {
                throw new NotExistsException();
            }

            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get all transaction by account id success",
                Result = result
            };

        }
        #endregion
    }
}
