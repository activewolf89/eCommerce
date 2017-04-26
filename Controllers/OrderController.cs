using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class OrderController: Controller 
    {
            private eCommerceContext _context;
        
        public OrderController(eCommerceContext context)
        {
            _context = context;
        }



        [HttpGet]
        [Route("orders")]
        public IActionResult orders()
        {
            List<Order> myOrderedList = _context.Order 
            .Include(o => o.Customer)
            .Include(p => p.Product)
            .ToList();
            ViewBag.myOrderedList = myOrderedList;
            return View();
        }
        [HttpGet]
        [Route("initialorders")]
        public JsonResult initialorders()
        {
            List<Product> listOfProduct = _context.Product.ToList();
            List<Customer> listOfCustomer = _context.Customer.ToList();
            return Json(new{product = listOfProduct, customer = listOfCustomer});
        }
    [HttpPost]
    [Route("orderup")]
    public IActionResult orderup(string customer, int order,string product)
    {
        Customer purchaseCustomer = _context.Customer.SingleOrDefault(cust => cust.CustomerName == customer);
        Product purchasedProduct = _context.Product.SingleOrDefault(prod => prod.ProductName == product);

        Order newOrder = new Order{
            Created_At = DateTime.Now,
            CustomerId = purchaseCustomer.CustomerId,
            ProductId = purchasedProduct.ProductId,
            Quantity = order 
        };
        _context.Add(newOrder);
        Product aProduct = _context.Product.SingleOrDefault(p => p.ProductName == product);
        aProduct.Quantity = aProduct.Quantity - order;
        _context.SaveChanges();
        return RedirectToAction("orders");
    }
    }
}