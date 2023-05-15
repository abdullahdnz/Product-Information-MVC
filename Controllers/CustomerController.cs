using Microsoft.AspNetCore.Mvc;
using ProductInfo.Data;
using ProductInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext context;

        public CustomerController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var value = context.Customers.ToList();
            return View(value);
        }

        public IActionResult Detail(int id)
        {
            var value = context.Customers.Find(id);
            return View(value);
        }

        public IActionResult Delete(int id)
        {
            var value = context.Customers.Find(id);
            context.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = context.Customers.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            var value = context.Customers.Find(customer.ID);
            value.Name = customer.Name;
            value.Lastname = customer.Lastname;
            value.Username = customer.Username;
            value.Mail = customer.Mail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
