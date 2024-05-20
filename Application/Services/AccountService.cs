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
    }
}
