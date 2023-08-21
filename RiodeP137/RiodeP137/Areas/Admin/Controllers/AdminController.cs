using System;
using Microsoft.AspNetCore.Mvc;

namespace RiodeP137.Areas.Manage.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

