using Microsoft.EntityFrameworkCore;

namespace eCommerce.Models
{
    public class eCommerceContext : DbContext 
    {
        public eCommerceContext(DbContextOptions<eCommerceContext> options): base(options){}
        public DbSet<Product> Product{get;set;}
        public DbSet<Customer> Customer{get;set;}
        public DbSet<Order> Order{get;set;}
    }
}