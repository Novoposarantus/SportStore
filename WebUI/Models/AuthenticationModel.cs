﻿using System.ComponentModel.DataAnnotations;

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
        [RegularExpression(EmailRegularExpression, ErrorMessage ="Use normal email adress")]
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
        [RegularExpression("^[+7|8]{1}[0-9]+$", ErrorMessage ="Write currect phone number")]
        public string PhoneNumber { get; set; }
        const string EmailRegularExpression = @"(?: (?:\r\n)?[ \t])*(?:(?:(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*|(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)*\<(?:(?:\r\n)?[ \t])*(?:@(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*(?:,@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*)*:(?:(?:\r\n)?[ \t])*)?(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*\>(?:(?:\r\n)?[ \t])*)|(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)*:(?:(?:\r\n)?[ \t])*(?:(?:(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*|(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)*\<(?:(?:\r\n)?[ \t])*(?:@(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*(?:,@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*)*:(?:(?:\r\n)?[ \t])*)?(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*\>(?:(?:\r\n)?[ \t])*)(?:,\s*(?:(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*|(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)*\<(?:(?:\r\n)?[ \t])*(?:@(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*(?:,@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*)*:(?:(?:\r\n)?[ \t])*)?(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*\>(?:(?:\r\n)?[ \t])*))*)?;\s*)";
    }
}