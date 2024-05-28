using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.AccountViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        #region  Get Account By Email
        public async Task<BaseResponseModel> GetAccountByEmailAsync(string email)
        {
            var account = await _unitOfWork.AccountRepo.GetAccountByEmailAsync(email);
            var result = _mapper.Map<AccountDetailViewModel>(account);

            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get user detail success",
                Result = result
            };
        }
        #endregion

        #region Get User Detail 
        public async Task<BaseResponseModel> GetUserDetailAsync(string id)
        {
            var user = await _unitOfWork.AccountRepo.GetAccountByIdAsync(id) ?? throw new NotExistsException();
            var result = _mapper.Map<AccountDetailViewModel>(user);

            return new SuccessResponseModel {
                Status = StatusCodes.Status200OK,
                Message = "Get user detail success",
                Result = result};
        }
        #endregion

        #region Get User List Pagination
        public async Task<Pagination<AccountDetailViewModel>> GetUserListPaginationAsync(int pageIndex = 0, int pageSize = 10)
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
            var users = await _unitOfWork.AccountRepo.ToPaginationAsync(pageIndex, pageSize);

            var result = _mapper.Map<Pagination<AccountDetailViewModel>>(users);

            return result;
        }
        #endregion

        #region Update UserDetail
        public async Task<AccountDetailViewModel?> UpdateUserDetailASync(string id, AccountUpdateModel model)
        {
            // retrieve user with the id
            var exisedUser = await _unitOfWork.AccountRepo.GetAccountByIdAsync(id);
            // update user with the new data
            _mapper.Map(model, exisedUser);
            _unitOfWork.AccountRepo.Update(exisedUser);
            await _unitOfWork.SaveChangesAsync();
            // map user entity to user detail model
            var result = _mapper.Map<AccountDetailViewModel>(exisedUser);
            return result;
        }
        #endregion
    }
}
