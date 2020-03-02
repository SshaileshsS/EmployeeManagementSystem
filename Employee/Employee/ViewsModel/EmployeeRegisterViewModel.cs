using Employee.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.ViewsModel
{
    public class EmployeeRegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "isEmailInUse" , controller:"Account")]
        [ValidEmailDomain(allowedDomain: "Being9amer.com" ,
            ErrorMessage = "Email domain must be being9amer.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
