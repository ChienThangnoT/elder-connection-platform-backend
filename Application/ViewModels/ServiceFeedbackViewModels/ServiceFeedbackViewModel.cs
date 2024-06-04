using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ServiceFeedbackViewModels
{
	public class ServiceFeedbackViewModel
	{
		public int ServiceFeedbackId { get; set; }

		public int PostId { get; set; }

		public string? CustomerId { get; set; }

		public string? FeedbackContent { get; set; }

		public int RatingStars { get; set; }

		public DateTime CreateAt { get; set; }
	}
}
