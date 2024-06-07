using Application.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
	public interface ITrainingProgramRepository : IGenericRepository<TrainingProgram>
	{
		Task<Pagination<TrainingProgram>> GetAllTrainingProgramAsync(int pageIndex, int pageSize);

        Task<TrainingProgram> GetTrainingProgramByIdAsync(int trainingProgramId);
    }
}
