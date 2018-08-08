using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [RegularExpression(@"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9A-Za-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9A-Za-z][-\w]*[0-9A-Za-z]*\.)+[A-Za-z0-9]{2,17}))$",ErrorMessage ="Use normal email adress")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Age must be numeric")]
        public int Age { get; set; }
        [Required]
        [RegularExpression("^[+7|8]{1}[0-9]+$",ErrorMessage ="Write currect phone number")]
        public string PhoneNumber { get; set; }
    }
}