using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace RiodeP137.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<UserBasket> UserBaskets { get; set; }
    }
}

