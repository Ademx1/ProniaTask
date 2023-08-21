
using RiodeP137.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiodeP137.Models
{
    public class Product : BaseEntity
    {
        [Required, MaxLength(64)]
        public string Name { get; set; }
        public string Brand { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, Range(0, Double.MaxValue)]
        public double CostPrice { get; set; }
        [Required, Range(0, Double.MaxValue)]
        public double SellPrice { get; set; }
        [Required, Range(0, 100)]
        public int DiscountPercent { get; set; } = 0;
        [Required, Range(0, Int32.MaxValue)]
        public int StockCount { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ProductBadges> ProductBadges { get; set; }
        public ICollection<ProductColors> ProductColors { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }
        [NotMapped]
        public IFormFile MainImg { get; set; }
        [NotMapped]
        public IFormFile HoverImg { get; set; }
        [NotMapped]
        public List<IFormFile> OtherImgs { get; set; }
        [NotMapped]
        public List<int> ColorIds { get; set; }
        [NotMapped]
        public List<int> BadgeIds { get; set; }


    }
}