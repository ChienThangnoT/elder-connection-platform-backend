using Domain.Enums.AccountEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AccountViewModels
{
    public class AccountUpdateModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public AccountGender? Sex { get; set; }

        public string? Biography { get; set; }
        
        public string? PhoneNumber { get; set; }

        public string? ProfilePicture { get; set; }

        public DateTime? Birthday { get; set; }
    }
}
