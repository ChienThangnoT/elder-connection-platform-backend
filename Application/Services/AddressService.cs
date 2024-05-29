using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.AddressViewModels;
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
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region  Get Account Address By Account Id
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
        #endregion

        public async Task<BaseResponseModel> AddAccountAddressAsync(AddressAddModel addressAddModel)
        {
            var isExistAccount = await _unitOfWork.AccountRepo.GetAccountByIdAsync(addressAddModel.AccountId) ?? throw new NotExistsException();

            var address = _mapper.Map<Address>(addressAddModel);
            await _unitOfWork.AddressRepo.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status201Created,
                Message = "Add address success.",
                Result = addressAddModel
            };
        }
    }
}
