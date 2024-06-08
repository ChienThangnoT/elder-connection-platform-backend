using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ConnectorFeedbackViewModels
{
	public class ConnectorFeedbackViewModel
	{
		public int RatingConnectorId { get; set; }

		public int TaskId { get; set; }

		public string? CustomerId { get; set; }

		public string? ConnectorId { get; set; }

		public bool IsRatingStatus { get; set; }

		public DateTime? RatingDate { get; set; }

		public int RatingStars { get; set; }
	}
}
