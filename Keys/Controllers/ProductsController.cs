using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Keys.Models;
using Keys.ViewModels;

namespace Keys.Controllers
{
    public class ProductsController : Controller
    {
        private Context db = new Context();

        // GET: Products
        public ActionResult Index()
        {
            var model = new ProductViewModel()
            {
                ProductList = db.Products.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ProductViewModel prod)
        {

            if (prod.Product.Id > 0)
            {
                var Name = prod.Product.Name;
                Product product = db.Products.Where(c => c.Name == Name).SingleOrDefault();
                if (product != null && product.Id != prod.Product.Id)
                {
                    return Json(false);
                }
                Product pro = db.Products.Where(c => c.Id == prod.Product.Id).SingleOrDefault();
                pro.Name = prod.Product.Name;
                pro.Price = prod.Product.Price;
                db.SaveChanges();
            }
            else
            {
                var Name = prod.Product.Name;
                Product product = db.Products.Where(c => c.Name == Name).SingleOrDefault();
                if (product != null)
                {
                    return Json(false);
                }
                Product pd = new Product()
                {
                    Name = prod.Product.Name,
                    Price = prod.Product.Price
                };
                db.Products.Add(pd);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Delete Product
        public ActionResult DeleteProduct(int productId)
        {
            bool result = false;
            Product product = db.Products.SingleOrDefault(x => x.Id == productId);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Update Product
        public ActionResult EditProduct(int productId)
        {

            Product product = db.Products.Where(c => c.Id == productId).SingleOrDefault();
            ProductViewModel model = new ProductViewModel()
            {
                Product = product
            };
            return PartialView("EditPartial", model);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
