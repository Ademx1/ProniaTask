using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiodeP137.DataAccess;
using RiodeP137.Models;
using RiodeP137.ViewModels;
using RiodeP137.DataAccess;
using RiodeP137.ViewModels;
using System.ComponentModel;

namespace RiodeP137.AppCode.ViewComponents
{
    public class FilterViewComponent : ViewComponent
    {
        private readonly RiodeDbContext context;

        public FilterViewComponent(RiodeDbContext context)
        {
            this.context = context;
        }
        public IViewComponentResult Invoke()
        {
            FilterItemsVM itemsVM = new()
            {
                Categories = context.Categories.Include(c => c.Children).ToList(),
                Colors = context.Colors.ToList(),
                MinPrice = (int)context.Products.OrderBy(p => p.SellPrice).FirstOrDefault().SellPrice,
                MaxPrice = (int)context.Products.OrderByDescending(p => p.SellPrice).FirstOrDefault().SellPrice

            };
            return View(itemsVM);
        }

    }
}