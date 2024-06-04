using Application.ResponseModels;
using Application.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserService
    {
        public Task<BaseResponseModel> SignUpAsync(AccountSignUpModel model);
        public Task<BaseResponseModel> SignUpConnectorAsync(ConnectorSignUpModel model);
        public Task<BaseResponseModel> ConfirmEmail(string tokenReset, string memberEmail);
        public Task<BaseResponseModel> SignInAccountAsync(SignInModel model);
        public Task<BaseResponseModel> RefreshToken(TokenModel tokenModel);
    }
}
