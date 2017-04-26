using System;
using System.Collections.Generic;

namespace eCommerce.Models 
{
        public class Customer 
    {
        public int CustomerId{get;set;}
        public string CustomerName{get;set;}
        public DateTime Created_At{get;set;}
       
       public List<Order> OrderList {get;set;}
        public Customer()
        {
            OrderList = new List<Order>();
        }
    }
}