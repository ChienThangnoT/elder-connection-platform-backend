using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ElderInformationViewModels
{
	public class ElderInformationUpdateModel
	{
		public string? Name { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? ProfilePicture { get; set; }
		public int Sex { get; set; }
		public string? Pathology { get; set; }
		public string? ChildId { get; set; }
	}
}
