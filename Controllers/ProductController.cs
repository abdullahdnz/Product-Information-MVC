using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductInfo.Data;
using ProductInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext context;

        public ProductController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var value = context.Products.ToList();
            return View(value);
        }

        public IActionResult Detail(int id)
        {
            var value = context.Products.Find(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> value = (from p in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = p.Name,
                                              Value = p.ID.ToString()
                                          }).ToList();
            ViewBag.v = value;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = context.Products.Find(id);
            context.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = context.Products.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var value = context.Products.Find(product.ID);
            value.Name = product.Name;
            value.Brand = product.Brand;
            value.Price = product.Price;
            value.Stock = product.Stock;
            value.CategoryID = product.CategoryID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
