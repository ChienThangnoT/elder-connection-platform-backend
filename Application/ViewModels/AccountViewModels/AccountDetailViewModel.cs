using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AccountViewModels
{
    public class AccountDetailViewModel
    {
        public string id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Biography { get; set; }

        public string? ProfilePicture { get; set; }

        public DateTime Birthday { get; set; }

        public int Sex { get; set; }

        public int Status { get; set; }

        public string? WalletBalance { get; set; }

        public DateTime? CreateAt { get; set; }
    }
}
