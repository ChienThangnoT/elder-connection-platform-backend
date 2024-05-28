using Domain.Enums.AddressEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AddressViewModels
{
    public class AddressAddModel
    {
        public int AddressId { get; set; }

        public string? AccountId { get; set; }

        public string? AddressName { get; set; }

        public string? AddressDetail { get; set; }

        public string? AddressDescription { get; set; }

        public HomeType HomeType { get; set; }

        public string? ContactName { get; set; }

        public string? ContactPhone { get; set; }
    }
}
