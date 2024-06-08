using Application.ResponseModels;
using Application.ViewModels.TrainingProgramViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface ITrainingProgramService
	{
		Task<BaseResponseModel> AddTrainingProgramAsync(TrainingProgramAddModel trainingProgramAddModel);
		Task<BaseResponseModel> GetAllTrainingProgramAsync(int pageIndex, int pageSize);
		Task<BaseResponseModel> UpdateTrainingProgramAsync(int trainingProgramId, TrainingProgramUpdateModel trainingProgramUpdateModel);
		Task<BaseResponseModel> RemoveTrainingProgramAsync(int trainingProgramId);

		Task<BaseResponseModel> GetTrainingProgramDetailAsync(int trainingProgramId);
	}
}
