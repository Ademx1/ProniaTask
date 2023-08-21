using RiodeP137.Models;

namespace RiodeP137.Models
{
    public class Badge : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductBadges> ProductBadges { get; set; }
    }
}