using System;
using System.ComponentModel.DataAnnotations;

namespace RiodeP137.ViewModels
{
    public class LoginVM
    {
        [Required, StringLength(100)]
        public string UserName { get; set; }
        [Required, StringLength(100), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

