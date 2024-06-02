using Domain.Enums.AddressEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AddressViewModels
{
    public class AddressUpdateModel
    {
        public string? AddressName { get; set; }

        public string? AddressDetail { get; set; }

        public string? AddressDescription { get; set; }

        public HomeType HomeType { get; set; }

        public string? ContactName { get; set; }

        [Required(ErrorMessage = "Account phone is required!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone must be exactly 10 characters.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string? ContactPhone { get; set; }
    }
}
