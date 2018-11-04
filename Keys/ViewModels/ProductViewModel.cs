using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Keys.Models;

namespace Keys.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> ProductList { get; set; }
        public Product Product { get; set; }
    }
}