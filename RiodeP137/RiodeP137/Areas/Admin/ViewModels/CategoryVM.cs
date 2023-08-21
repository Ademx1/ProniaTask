using System;
using RiodeP137.DataAccess;
using RiodeP137.Models;

namespace RiodeP137.Areas.Manage.ViewModels
{
    public class CategoryVM
    {
        public ICollection<Category> Categories { get; set; }
        public Category Category { get; set; }
        public RiodeDbContext Context { get; }




    }
}

