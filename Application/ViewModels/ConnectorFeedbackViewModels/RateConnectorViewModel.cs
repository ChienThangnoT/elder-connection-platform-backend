using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ConnectorFeedbackViewModels
{
    public class RateConnectorViewModel
    {
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string ConnectorId { get; set; }

        [Required]
        [Range(1, 5)]
        public int RatingStars { get; set; }
    }
}
