using Application.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.FavoriteListViewModels
{
    public class FavoriteListViewModel
    {
        public int favoriteListId { get; set; }

        public string? customerId { get; set; }

        public string? connectorId { get; set; }

    }
}
