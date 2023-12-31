﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiodeP137.DataAccess;
using RiodeP137.Models;
using RiodeP137.Extentions;


namespace RiodeP137.Areas.Manage.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        RiodeDbContext _context { get; }
        public ProductController(RiodeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.ProductImages).Include(p => p.Category).ToList();

            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.Badges = _context.Badges;
            //ViewBag.Colors = _context.Colors;
            ViewBag.Categories = _context.Categories;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            ViewBag.Badges = _context.Badges;
            //ViewBag.Colors = _context.Colors;
            ViewBag.Categories = _context.Categories;
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (product.MainImg is null)
            {
                ModelState.AddModelError("MainImg", "Zəhmət olmasa şəkil seçin");
                return View();
            }
            if (product.SellPrice < product.CostPrice)
            {
                ModelState.AddModelError("SellPrice", "Satış qiyməti maya dəyərindən kiçik ola bilməz!");
            }
            #region Image
            //other images
            var productImgs = product.OtherImgs;
            List<ProductImages> images = new List<ProductImages>();
            if (productImgs != null)
            {
                foreach (var image in productImgs)
                {
                    if (!image.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("MainImage", "Yüklədiyiniz fayl şəkil deyil");
                        return View();
                    }
                    if (!image.CheckFileSize(2))
                    {
                        ModelState.AddModelError("MainImage", "Yüklədiyiniz şəkil 2mb-dan artıq olmamalıdır");
                        return View();
                    }
                }

                foreach (var image in productImgs)
                {
                    string imagename = Guid.NewGuid() + image.CutFileName();
                    image.SaveFile(Path.Combine("assets", "images", imagename));
                    images.Add(new()
                    {
                        ImageName = imagename,
                        Product = product,
                        IsMain = null
                    });

                }
            }
            //main image
            var mainimg = product.MainImg;
            if (!mainimg.CheckFileType("image/"))
            {
                ModelState.AddModelError("MainImage", "Yüklədiyiniz fayl şəkil deyil");
                return View();
            }
            if (!mainimg.CheckFileSize(2))
            {
                ModelState.AddModelError("MainImage", "File is too big");
                return View();
            }
            string mainImgName = Guid.NewGuid() + mainimg.CutFileName();
            mainimg.SaveFile(Path.Combine("assets", "images", mainImgName));
            images.Add(new()
            {
                ImageName = mainImgName,
                IsMain = true,
                Product = product
            });
            // hover image
            var hoverImg = product.HoverImg;
            if (hoverImg != null)
            {
                if (!hoverImg.CheckFileType("image/"))
                {
                    ModelState.AddModelError("MainImage", "Yüklədiyiniz fayl şəkil deyil");
                    return View();
                }
                if (!hoverImg.CheckFileSize(2))
                {
                    ModelState.AddModelError("MainImage", "File is too big");
                    return View();
                }
                string hoverImgName = Guid.NewGuid() + hoverImg.CutFileName();
                hoverImg.SaveFile(Path.Combine("assets", "images", hoverImgName));
                images.Add(new()
                {
                    ImageName = hoverImgName,
                    IsMain = false,
                    Product = product
                });

            }
            #endregion

            product.ProductImages = images;
            //if (product.ColorIds != null)
            //{
            //    product.ProductColors = new List<ProductColors>();
            //    foreach (var item in product.ColorIds)
            //    {
            //        product.ProductColors.Add(new()
            //        {
            //            ColorId = item,
            //            Product = product
            //        });
            //    }
            //}
            if (product.BadgeIds != null)
            {
                product.ProductBadges = new List<ProductBadges>();
                foreach (var item in product.BadgeIds)
                {
                    product.ProductBadges.Add(new()
                    {
                        BadgeId = item,
                        Product = product
                    });
                }
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.Badges = _context.Badges;
            //ViewBag.Colors = _context.Colors;
            ViewBag.Categories = _context.Categories;
            if (id is null) return BadRequest();
            var prod = _context.Products.Where(p => p.Id == id)
                                        .Include(p => p.ProductImages)
                                        .Include(p => p.ProductBadges)
                                        .ThenInclude(p => p.Badge)
                                        //.Include(p => p.ProductColors)
                                        //.ThenInclude(p => p.Color)
                                        .SingleOrDefault();

            if (prod is null) return NotFound();
            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Product product)
        {

            if (id is null || id == 0) return BadRequest();

            var edited = _context.Products.Where(p => p.Id == id)
                                        .Include(p => p.ProductImages)
                                        .Include(p => p.ProductBadges)
                                        .ThenInclude(p => p.Badge)
                                        //.Include(p => p.ProductColors)
                                        //.ThenInclude(p => p.Color)
                                        .SingleOrDefault();
            ViewBag.Badges = _context.Badges;
            //ViewBag.Colors = _context.Colors;
            ViewBag.Categories = _context.Categories;

            if (edited is null) return NotFound();
            edited.Name = product.Name;
            edited.Brand = product.Brand;
            edited.Description = product.Description;
            edited.CategoryId = product.CategoryId;
            edited.CostPrice = product.CostPrice;
            edited.SellPrice = product.SellPrice;
            edited.DiscountPercent = product.DiscountPercent;
            //if (product.ColorIds != null)
            //{
            //    List<ProductColors> productColors = new();
            //    foreach (var colorId in product.ColorIds)
            //    {
            //        productColors.Add(new() { ColorId = colorId, ProductId = product.Id });
            //    }
            //    edited.ProductColors = productColors;
            //}
            //else
            //{
            //    edited.ProductColors.Clear();
            //}
            if (product.BadgeIds != null)
            {
                List<ProductBadges> productBadges = new();
                foreach (var badgeId in product.BadgeIds)
                {
                    productBadges.Add(new() { BadgeId = badgeId, ProductId = product.Id });
                }
                edited.ProductBadges = productBadges;
            }
            else
            {
                edited.ProductBadges.Clear();
            }
            List<IFormFile> newImages = product.OtherImgs;
            List<ProductImages> images = new List<ProductImages>();
            if (newImages != null)
            {
                foreach (var img in newImages)
                {
                    string imgUrl = Guid.NewGuid() + img.CutFileName();
                    img.SaveFile(Path.Combine("assets", "images", imgUrl));
                    images.Add(new ProductImages
                    {
                        ImageName = imgUrl,
                        IsMain = null,
                        Product = edited,
                    });
                }

                foreach (var imageToAdd in images)
                {
                    edited.ProductImages.Add(imageToAdd);
                }
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult SwitchStatus(int? id)
        {
            if (id is null)
            {
                var response = new
                {
                    error = true,
                    message = "tapilmadi"
                };
                return Json(response);
            }
            var product = _context.Products.Find(id);
            if (product is null)
            {
                var response = new
                {
                    error = true,
                    message = "tapilmadi"
                };
                return Json(response);
            }
            if (product.IsDisable == false)
            {
                product.IsDisable = true;
            }
            else
            {
                product.IsDisable = false;
            }
            _context.SaveChanges();
            return Json(new
            {
                error = false,
                message = "ok"
            });
        }
    }
}