using System;
using RiodeP137.Models;

namespace RiodeP137.ViewModels
{
    public class FilterItemsVM
    {
        public ICollection<Category> Categories { get; set; }
        public ICollection<Color> Colors { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}

