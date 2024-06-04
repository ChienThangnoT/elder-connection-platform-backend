using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.SaleViewModels
{
	public class SaleAddModel
	{
		public string SaleName { get; set; }
		public string? ImageURL { get; set; }
		public string SaleDescription { get; set; }
		public float SalePercent { get; set; }
	}
}
