using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiodeP137.Models
{
    public class Slider : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool? IsLeftSide { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}

