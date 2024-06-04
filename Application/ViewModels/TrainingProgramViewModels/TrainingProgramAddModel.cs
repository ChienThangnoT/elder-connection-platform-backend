using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.TrainingProgramViewModels
{
	public class TrainingProgramAddModel
	{
		public string? TraningProgramLevel { get; set; }

		public string? TraningProgramTitle { get; set; }

		public string? TraningProgramContent { get; set; }

		public string? TraningProgramDuration { get; set; }

		public bool Status { get; set; }
	}
}
