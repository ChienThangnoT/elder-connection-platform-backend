using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AddressViewModels
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AddressName { get; set; }

        public string? AddressDetail { get; set; }

        public string? AddressDescription { get; set; }

        public int HomeType { get; set; }

        public string? ContactName { get; set; }

        public string? ContactPhone { get; set; }
    }
}
