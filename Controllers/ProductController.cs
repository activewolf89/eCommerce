using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using eCommerce.Models;
using System.Linq;

namespace eCommerce.Controllers
{
    public class ProductController: Controller 
    {
        private eCommerceContext _context;   

        public ProductController(eCommerceContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/products")]
        public IActionResult products()
        {
            List<Product> listofProducts = _context.Product
            .ToList();
            ViewData["error"] = TempData["error"];
            ViewBag.listOfProducts = listofProducts;
            
            return View();
        }

        [HttpPost]
        [Route("/productadd")]

        public IActionResult productadd(ProductModelView aProduct)
        {
            System.Console.WriteLine(ModelState);
            if(ModelState.IsValid)
            {
                List<Product> listofAllProducts = _context.Product.Where(p => p.ProductName == aProduct.ProductName).ToList();
                if(listofAllProducts.Count > 0)
                {
                    foreach(Product singleProduct in listofAllProducts)
                    {
                        singleProduct.Quantity += aProduct.Quantity;
                        singleProduct.Price += aProduct.Price;
                        _context.SaveChanges();

                    }   
                    return RedirectToAction("products");
                }
                Product newProduct = new Product
                {
                    ProductName = aProduct.ProductName,
                    Quantity = aProduct.Quantity,
                    Price = aProduct.Price,
                    ImgSrc = aProduct.ImgSrc,
                    Description = aProduct.Description, 
                    Created_At = DateTime.Now
                };
                _context.Add(newProduct);
                _context.SaveChanges();
                
            }
            List<Product> listofProducts = _context.Product
            .ToList();
            ViewBag.listOfProducts = listofProducts;
            return View("products");
        }
        [HttpPost]
        [Route("/searchfilter")]
        public IActionResult searchfilter(string searchword)
        {
            List<Product> myFilterProductList = _context.Product
            .Where(product => product.ProductName.Contains(searchword))
            .ToList();
             List<Product> AllFilterProductList = _context.Product.ToList();
             
            ViewBag.listOfProducts = myFilterProductList;
            if(myFilterProductList.Count < 1)
            {
                ViewBag.listOfProducts = AllFilterProductList;
            }
            return View("products");
        }
        [HttpPost]
        [Route("/updateproduct")]
        public IActionResult updateproduct(int productid, string updatedescription, string updatename, int updatequantity,int updateprice,string updateimgsrc)
        {
            Product updateAProduct = _context.Product.SingleOrDefault(p => p.ProductId == productid);
            updateAProduct.ProductName = updatename;
            updateAProduct.Quantity = updatequantity;
            updateAProduct.Price = updateprice;
            updateAProduct.ImgSrc = updateimgsrc;
            updateAProduct.Description = updatedescription;
            _context.SaveChanges();
            return RedirectToAction("products");
        }
    }
}