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
    public class ProductSoldsController : Controller
    {
        private Context db = new Context();

        // GET: ProductSolds
        public ActionResult Index()
        {
            var model = new SalesViewModel()
            {
                Customers = db.Customers.ToList(),
                Products = db.Products.ToList(),
                Stores = db.Stores.ToList(),
                SalesList = db.ProductSolds.Include(p => p.Customer).Include(p => p.Product).Include(p => p.Store).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SalesViewModel model)
        {
            if (Convert.ToDateTime(model.ProductSold.DateSold) > DateTime.Now)
            {
                return Json(false);
            }
            if (model.ProductSold.Id > 0)
            {
                ProductSold ps = db.ProductSolds.Where(c => c.Id == model.ProductSold.Id).SingleOrDefault();
                ps.CustomerId = model.ProductSold.CustomerId;
                ps.ProductId = model.ProductSold.ProductId;
                ps.StoreId = model.ProductSold.StoreId;
                ps.DateSold = model.ProductSold.DateSold;
                db.SaveChanges();
            }
            else
            {
                ProductSold ps = new ProductSold()
                {
                    CustomerId = model.ProductSold.CustomerId,
                    ProductId = model.ProductSold.ProductId,
                    StoreId = model.ProductSold.StoreId,
                    DateSold = model.ProductSold.DateSold
                };

                db.ProductSolds.Add(ps);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // Delete Sale
        public ActionResult DeleteSale(int saleId)
        {
            bool result = false;
            ProductSold sale = db.ProductSolds.SingleOrDefault(x => x.Id == saleId);
            if (sale != null)
            {
                db.ProductSolds.Remove(sale);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Update Sale
        public ActionResult EditSale(int saleId)
        {
            ProductSold ps = db.ProductSolds.Where(c => c.Id == saleId).SingleOrDefault();
            List<Customer> list = db.Customers.ToList();
            ViewBag.CustomerList = new SelectList(list, "Id", "Name");
            List<Product> list2 = db.Products.ToList();
            ViewBag.ProductList = new SelectList(list2, "Id", "Name");
            List<Store> list3 = db.Stores.ToList();
            ViewBag.StoreList = new SelectList(list3, "Id", "Name");
            SalesViewModel model = new SalesViewModel()
            {
                ProductSold = ps
            };
            return PartialView("EditSale", model);
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
