using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Keys.Models
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection") { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ProductSold> ProductSolds { get; set; }
    }
}