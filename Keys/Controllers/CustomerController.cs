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
    public class CustomerController : Controller
    {
        private Context db = new Context();

        //Get Customers
        public ActionResult Index()
        {
            var model = new CustomerViewModel()
            {
                CustomersList = db.Customers.ToList()
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(CustomerViewModel cust)
        {
            if (cust.Customer.Id > 0)
            {
                var Name = cust.Customer.Name;
                Customer customer = db.Customers.Where(c => c.Name == Name).SingleOrDefault();
                if (customer != null && customer.Id != cust.Customer.Id)
                {
                    return Json(false);
                }
                Customer cus = db.Customers.Where(c => c.Id == cust.Customer.Id).SingleOrDefault();
                cus.Name = cust.Customer.Name;
                cus.Address = cust.Customer.Address;
                db.SaveChanges();
            }
            else
            {
                var Name = cust.Customer.Name;
                Customer customer = db.Customers.Where(c => c.Name == Name).SingleOrDefault();
                if (customer != null)
                {
                    return Json(false);
                }
                Customer cs = new Customer()
                {
                    Name = cust.Customer.Name,
                    Address = cust.Customer.Address
                };
                db.Customers.Add(cs);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // Delete Customer
        public ActionResult DeleteCustomer(int customerId)
        {
            bool result = false;
            Customer customer = db.Customers.SingleOrDefault(x => x.Id == customerId);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Update Customer
        public ActionResult EditCustomer(int customerId)
        {

            Customer customer = db.Customers.Where(c => c.Id == customerId).SingleOrDefault();
            CustomerViewModel model = new CustomerViewModel()
            {
                Customer = customer
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
