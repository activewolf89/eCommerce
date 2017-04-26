using System;
using System.Collections.Generic;

namespace eCommerce.Models 
{
    public class Order
    {
        public int OrderId{get;set;}
        public DateTime Created_At{get;set;}

         public int CustomerId{get;set;}
         public Customer Customer{get;set;}

         public int ProductId{get;set;}
         public Product Product{get;set;}
         public int Quantity{get;set;}
    }
}