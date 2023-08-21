using System;
namespace RiodeP137.ViewModels
{
    public class FromFilterVM
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public List<int> ColorIds { get; set; }
        public int CategoryId { get; set; }
    }
}

