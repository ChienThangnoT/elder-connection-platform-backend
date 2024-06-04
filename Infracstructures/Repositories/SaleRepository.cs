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
	public class SaleRepository : GenericRepository<Sale>, ISaleRepository
	{
		private readonly ElderConnectionContext _context;
		public SaleRepository(ElderConnectionContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Pagination<Sale>> GetAllSaleAsync(int pageIndex, int pageSize)
		{
			var query = _context.Sales.AsQueryable();
			return await ToListPaginationAsync(query, pageIndex, pageSize);
		}
	}
}
