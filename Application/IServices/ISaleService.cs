using Application.ResponseModels;
using Application.ViewModels.SaleViewModels;
using Infracstructures.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface ISaleService
	{
		Task<BaseResponseModel> AddSaleAsync(SaleAddModel saleAddModel);
		Task<BaseResponseModel> GetAllSaleAsync(int pageSize, int pageIndex);
		Task<BaseResponseModel> GetSaleByIdAsync(int saleId);
		Task<BaseResponseModel> UpdateSaleAsync(int saleId, SaleUpdateModel saleUpdateModel);
		Task<BaseResponseModel> RemoveSaleAsync(int saleId);
	}
}
