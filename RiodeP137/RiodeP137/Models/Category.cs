using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiodeP137.Models
{
	public class Category : BaseEntity
	{
        [Required]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string ImageName { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> Children { get; set; }
        public ICollection<Product> Products { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}

