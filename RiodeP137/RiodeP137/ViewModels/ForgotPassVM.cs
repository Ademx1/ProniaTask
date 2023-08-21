using System;
using System.ComponentModel.DataAnnotations;

namespace RiodeP137.ViewModels
{
    public class ForgotPassVM
    {
        [Required]
        public string UserName { get; set; }
    }
}

