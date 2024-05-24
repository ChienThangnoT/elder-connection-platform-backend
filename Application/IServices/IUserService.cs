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
          public Task<bool> SignUpAsync(AccountSignUpModel model);
    }
}
