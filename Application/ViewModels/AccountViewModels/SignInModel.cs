﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AccountViewModels
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Email can not be blank!"), EmailAddress(ErrorMessage = "Please enter valid email!")]
        public required string AccountEmail { get; set; }
        [Required(ErrorMessage = "Password can not be blank!")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public required string AccountPassword { get; set; }
    }
}
