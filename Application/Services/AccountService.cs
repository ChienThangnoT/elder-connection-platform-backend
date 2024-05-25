using Application.IServices;
using Application.ViewModels.AccountViewModels;
using AutoMapper;
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

        #region GetUserDetailAsync
        public async Task<AccountDetailViewModel?> GetUserDetailAsync(string id)
        {
            // retrieve user with the id
            var user = await _unitOfWork.AccountRepo.GetAccountByIdAsync(id);

            // map user entity to user detail model
            var result = _mapper.Map<AccountDetailViewModel>(user);

            return result;
        }
        #endregion

        #region UpdateUserDetailASync
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
