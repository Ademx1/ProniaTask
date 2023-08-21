using System;
using System.ComponentModel.DataAnnotations;
using RiodeP137.Models;
using RiodeP137.Models;

namespace RiodeP137.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        [Required]
        public string ImageName { get; set; }
        public bool? IsMain { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}

