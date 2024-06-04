using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AccountViewModels
{
    public class ConnectorSignUpModel
    {
        [Required(ErrorMessage = "Account phone is required!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone must be exactly 10 characters.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public required string AccountPhone { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string CccdNumber { get; set; }

        [Required(ErrorMessage = "Email is required!"), EmailAddress(ErrorMessage = "Please enter valid email!")]
        public required string AccountEmail { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 7, ErrorMessage = "Password must be 7-12 Character")]
        [PasswordPropertyText]
        public string AccountPassword { get; set; } = "";
        [Required(ErrorMessage = "Confirm Password is required!")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("AccountPassword", ErrorMessage = "Password and confirmation does not match!")]
        [StringLength(12, MinimumLength = 7, ErrorMessage = "Password must be 7-12 Character")]
        [PasswordPropertyText]
        public string ConfirmAccountPassword { get; set; } = "";
    }
}
