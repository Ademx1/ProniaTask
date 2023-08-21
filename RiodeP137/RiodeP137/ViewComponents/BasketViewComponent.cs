

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiodeP137.DataAccess;
using RiodeP137.Models;
using Newtonsoft.Json;



namespace RiodeP137.ViewComponents
{
    public class BasketViewComponent : ViewComponent
    {
        public BasketViewComponent(RiodeDbContext context)
        {
            Context = context;
        }

        public RiodeDbContext Context { get; }

        public IViewComponentResult Invoke()
        {

            var username = User.Identity.Name;

            ICollection<UserBasket> basket = new List<UserBasket>();
            if (username != null)
            {
                var user = Context.Users.Where(u => u.UserName == username).FirstOrDefault();
                basket = Context.UserBaskets.Where(ub => ub.AppUserId == user.Id)
                    .Include(b => b.Product)
                    .ThenInclude(p => p.ProductImages)
                    .ToList();

            }
            return View(basket);
        }
    }
}

