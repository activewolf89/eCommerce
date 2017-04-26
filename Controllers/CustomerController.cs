using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class CustomerController: Controller 
    {
        private eCommerceContext _context;
        
        public CustomerController(eCommerceContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("customers")]
        public IActionResult customers()
        {
            ViewBag.status = TempData["status"];
            List<Customer> myCustomerList = _context.Customer.ToList();
            ViewBag.Customer = myCustomerList;

            return View();
        }
        [HttpPost]
        [Route("addcustomer")]
        public IActionResult addcustomer(string customer_name)
        {
            if(customer_name == null)
            {
                TempData["status"] = "Customer name needs to have a value";
                return RedirectToAction("customers");
            }
            List<Customer> customerList = _context.Customer
            .Where(c => c.CustomerName == customer_name)
            .ToList();
            if(customerList.Count > 0)
            {
                TempData["status"] = "Customer is already in the system";
            }
            else 
            {
                Customer newCustomer = new Customer{
                    CustomerName = customer_name, 
                    Created_At = DateTime.Now
                };
                _context.Add(newCustomer);
                _context.SaveChanges();
            }
            return RedirectToAction("customers");
        }
        [HttpGet]
        [Route("customer/delete/{user_id}")]

        public JsonResult customerdelete(int user_id){

            System.Console.WriteLine(user_id);
            Customer aCustomer = _context.Customer.SingleOrDefault(customer => customer.CustomerId == user_id);
            _context.Remove(aCustomer);
            _context.SaveChanges();
            List<Customer> ListOfCustomer = _context.Customer.ToList();
            return Json(new{customerList = ListOfCustomer});
        }
    }
}