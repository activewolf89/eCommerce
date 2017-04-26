using System;
using System.Collections.Generic;

namespace eCommerce.Models 
{
        public class Product 
    {
        public int ProductId{get;set;}
        public string ProductName{get;set;}
        public int Quantity{get;set;}
        public double Price{get;set;}
        public string ImgSrc{get;set;}
        public string Description{get;set;}
        public DateTime Created_At{get;set;}
        public List<Order> OrderList{get;set;}
        public Product()
        {
            OrderList = new List<Order>();
        }
           
    }
}