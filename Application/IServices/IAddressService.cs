using Application.ResponseModels;
using Application.ViewModels.AddressViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAddressService
    {
        Task<BaseResponseModel> AddAccountAddressAsync(AddressAddModel addressAddModel);
        Task<BaseResponseModel> GetAccountAddressByAccountIdAsync(string accountId, int pageSize, int pageIndex);
        Task<BaseResponseModel> UpdateAccountAddressAsync(int addressId, AddressUpdateModel addressUpdateModel);
        Task<BaseResponseModel> DeleteccountAddressAsync(int addressId);

    }
}
