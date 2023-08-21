using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiodeP137.DataAccess;

namespace RiodeP137.AppCode.ViewComponents
{
    public class FourCrudProductViewComponent : ViewComponent
    {
        public FourCrudProductViewComponent(RiodeDbContext context)
        {
            Context = context;
        }

        public RiodeDbContext Context { get; }
        public IViewComponentResult Invoke()
        {
            var r = new Random();
            var products = Context.Products.Include(p => p.ProductImages).Include(p => p.ProductBadges).ThenInclude(pb => pb.Badge);
            var lengtg = products.Count();
            var randomprods = products.OrderBy(p => p.Name).Take(12).ToList();

            return View(randomprods);
        }

    }
}