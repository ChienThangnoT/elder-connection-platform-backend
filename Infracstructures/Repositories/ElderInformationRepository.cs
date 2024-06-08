﻿using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
	public class ElderInformationRepository : GenericRepository<ElderInformation>, IElderInformationRepository
	{
		private readonly ElderConnectionContext _context;
		public ElderInformationRepository(ElderConnectionContext context) : base(context)
		{
			_context = context;
		}

		public async Task<ElderInformation> GetElderInformationByChildIdAsync(string childId)
		{
			return await _context.ElderInformations.FirstOrDefaultAsync(x => x.ChildId == childId);
		}
	}
}
