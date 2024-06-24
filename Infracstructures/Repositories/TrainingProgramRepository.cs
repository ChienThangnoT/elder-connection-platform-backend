using Application.Common;
using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
	public class TrainingProgramRepository : GenericRepository<TrainingProgram>, ITrainingProgramRepository
	{
		private readonly ElderConnectionContext _context;
		public TrainingProgramRepository(ElderConnectionContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Pagination<TrainingProgram>> GetAllTrainingProgramAsync(int pageIndex, int pageSize)
		{
			var query = _context.TrainingPrograms.AsQueryable();
			if (!query.Any())
			{
				return null;
			}
			return await ToListPaginationAsync(query, pageIndex, pageSize);
		}

        public async Task<TrainingProgram> GetTrainingProgramByIdAsync(int trainingProgramId)
        {
			return await _dbSet.FirstOrDefaultAsync(tp => tp.TraningProgramId == trainingProgramId);
        }
    }
}
