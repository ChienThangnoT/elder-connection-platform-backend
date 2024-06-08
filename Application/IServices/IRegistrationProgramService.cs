using Application.ResponseModels;
using Application.ViewModels.RegistrationProgramViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IRegistrationProgramService
    {
        Task<BaseResponseModel> ApplyTrainingProgram(int trainingProgramId, string connectorId);
    }
}
