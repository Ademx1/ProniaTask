using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RiodeP137.Models;

namespace RiodeP137.DataAccess
{
    public class RiodeDbContext : IdentityDbContext<AppUser>
    {
        public RiodeDbContext(DbContextOptions<RiodeDbContext> opt) : base(opt)
        {

        }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBadges> ProductBadges { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColors> ProductColors { get; set; }
        public DbSet<ResetPasswordCode> ResetPasswordCodes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserBasket> UserBaskets { get; set; }
    }
}

