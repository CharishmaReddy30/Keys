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
    public class StoresController : Controller
    {
        private Context db = new Context();

        // GET: Stores
        public ActionResult Index()
        {
            var model = new StoreViewModel()
            {
                StoreList = db.Stores.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(StoreViewModel model)
        {
            if (model.Store.Id > 0)
            {
                var Name = model.Store.Name;
                Store stores = db.Stores.Where(c => c.Name == Name).SingleOrDefault();
                if (stores != null && stores.Id != model.Store.Id)
                {
                    return Json(false);
                }
                Store store = db.Stores.Where(c => c.Id == model.Store.Id).SingleOrDefault();
                store.Name = model.Store.Name;
                store.Address = model.Store.Address;
                db.SaveChanges();
            }
            else
            {
                var Name = model.Store.Name;
                Store stores = db.Stores.Where(c => c.Name == Name).SingleOrDefault();
                if (stores != null && stores.Id != model.Store.Id)
                {
                    return Json(false);
                }
                Store store = new Store();
                store.Name = model.Store.Name;
                store.Address = model.Store.Address;
                db.Stores.Add(store);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        // Delete Store
        public ActionResult DeleteStore(int storeId)
        {
            bool result = false;
            Store store = db.Stores.SingleOrDefault(x => x.Id == storeId);
            if (store != null)
            {
                db.Stores.Remove(store);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Update Store
        public ActionResult EditStore(int storeId)
        {

            Store store = db.Stores.Where(c => c.Id == storeId).SingleOrDefault();
            StoreViewModel model = new StoreViewModel()
            {
                Store = store
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
