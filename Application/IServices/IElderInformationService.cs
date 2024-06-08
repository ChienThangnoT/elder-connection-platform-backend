using Application.ResponseModels;
using Application.ViewModels.ElderInformationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface IElderInformationService
	{
		Task<BaseResponseModel> GetElderInformationByChildIdAsync(string childId);
		Task<BaseResponseModel> UpdateElderInformationAsync(int Id, ElderInformationUpdateModel elderInformationUpdateModel);
	}
}
