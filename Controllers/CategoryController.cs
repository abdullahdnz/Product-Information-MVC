using Microsoft.AspNetCore.Mvc;
using ProductInfo.Data;
using ProductInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext context;

        public CategoryController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var value = context.Categories.ToList();
            return View(value);
        }

        public IActionResult Detail(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }

        public IActionResult Delete(int id)
        {
            var value = context.Categories.Find(id);
            context.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var value = context.Categories.Find(category.ID);
            value.Name = category.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
