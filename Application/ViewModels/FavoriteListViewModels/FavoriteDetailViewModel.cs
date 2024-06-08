using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.FavoriteListViewModels
{
    public class FavoriteDetailViewModel
    {
        public int favoriteListId { get; set; }

        public string? customerId { get; set; }
        public string? connectorId { get; set; }

        public string? connectorFirstName { get; set; }
        public string? connectorLastName { get; set; }
        public string? connectorBiography { get; set; }
        public string? connectorSex { get; set; }
        public string? connectorEmail { get; set; }
        public string? connectorAvarageRating { get; set; }
        public string? connectorPhoneNumber { get; set; }
        public string? connectorIdentityNumber { get; set; }

    }
}
