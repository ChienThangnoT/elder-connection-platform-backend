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
            var account = await _unitOfWork.AccountRepo.GetAccountByIdAsync(accountId) 
                ?? throw new AccountAlreadyExistsException();
            var addressList = await _unitOfWork.AddressRepo.GetAccountAddressByAccountIdAsync(accountId, pageIndex, pageSize);

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
            _ = await _unitOfWork.AccountRepo.GetAccountByIdAsync(addressAddModel.AccountId) ?? throw new NotExistsException();

            var address = _mapper.Map<Address>(addressAddModel);
            await _unitOfWork.AddressRepo.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<AddressAddModel>(address);
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status201Created,
                Message = "Add address success.",
                Result = result
            };
        }

        public async Task<BaseResponseModel> UpdateAccountAddressAsync(int addressId, AddressUpdateModel addressUpdateModel)
        {
            var address = await _unitOfWork.AddressRepo.GetByIdAsync(addressId) ?? throw new NotExistsException();
            _mapper.Map(addressUpdateModel, address);
            _unitOfWork.AddressRepo.Update(address);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map(address, addressUpdateModel);
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Update account address success",
                Result = result
            };
        }

        public async Task<BaseResponseModel> DeleteccountAddressAsync(int addressId)
        {
            var address = await _unitOfWork.AddressRepo.GetByIdAsync(addressId) ?? throw new NotExistsException();
            _unitOfWork.AddressRepo.Remove(address);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Remove account address success",
            };
        }
    }
}
