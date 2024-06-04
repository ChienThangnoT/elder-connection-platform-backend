using Application.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
	public interface ISaleRepository : IGenericRepository<Sale>
	{
		Task<Pagination<Sale>> GetAllSaleAsync(int pageIndex, int pageSize);
	}
}
