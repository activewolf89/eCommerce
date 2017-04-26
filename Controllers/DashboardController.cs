using System.Collections.Generic;
using System.Linq;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class DashboardController : Controller
    {
            private eCommerceContext _context;
        
        public DashboardController(eCommerceContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult home()
        {
            if(TempData["searchword"] == null)
            {
            List<Product> myProductList = _context.Product
                .OrderByDescending(p => p.Created_At)
                .Take(5)
                .ToList();
                ViewBag.myProductList = myProductList;
            }
            else
            {
                string checkedWord = (string)TempData["searchword"];
            List<Product> myProductList = _context.Product
              .Where(p=>p.ProductName.Contains(checkedWord))
               .ToList();
                ViewBag.myProductList = myProductList;
            }
            ViewData["Partial"] = "Dashboard";
            
            List<Order> myRecentOrders = _context.Order 
                .OrderByDescending(o => o.Created_At)
                .Include(o => o.Customer)
                .Include(p => p.Product)
                .Take(3)
                .ToList();
            ViewBag.myRecentOrders = myRecentOrders;
            List<object> myListOfCustomersAndOrders = new List<object>();
            List<Customer> myRecentCustomers = _context.Customer 
                .Include(c => c.OrderList)
                .OrderByDescending(c => c.Created_At)
                .ToList();
            List<Order> newestCustomerOrders = _context.Order 
                .OrderByDescending(o => o.Created_At)
                .Include(o => o.Customer)
                .Include(p => p.Product)
                .ToList();
            
            for(var i = 0; i < 3; i++)
            {
                if(newestCustomerOrders[i].Created_At >= myRecentCustomers[i].Created_At)
                {
                    myListOfCustomersAndOrders.Add(newestCustomerOrders[i]);
                }
                else
                {
                    myListOfCustomersAndOrders.Add(myRecentCustomers[i]);
                }
            }
            ViewBag.Recents = myListOfCustomersAndOrders;
            return View();
        }
    [HttpGet]
    [Route("dashboard")]
    public IActionResult dashboard()
        {
            return  RedirectToAction("Home");
        }
    [HttpGet]
    [Route("showmoreproduct")]
    public JsonResult showmoreproduct()
        {
                List<Product> myProductList = _context.Product
                .OrderByDescending(p => p.Created_At)
                .ToList();
            return Json(new{myProducts = myProductList});
        }
    [HttpPost]
    [Route("searchproduct")]
    public IActionResult searchproduct(string searchstring)
        {   
            TempData["searchword"] = searchstring;
            return RedirectToAction("home");
            
        }
    }
}