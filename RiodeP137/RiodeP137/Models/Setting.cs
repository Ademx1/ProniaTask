using System;
using System.ComponentModel.DataAnnotations;

namespace RiodeP137.Models
{
    public class Setting : BaseEntity
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}

