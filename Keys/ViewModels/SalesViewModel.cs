using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Keys.Models;

namespace Keys.ViewModels
{
    public class SalesViewModel
    {
        public ProductSold ProductSold { get; set; }
        public List<ProductSold> SalesList { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Store> Stores { get; set; }
    }
}