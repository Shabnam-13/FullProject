using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_FullProject.DAL;
using WebApp_FullProject.Models;

namespace WebApp_FullProject.Areas.Admin.Controllers
{
    public class StoreController : Controller
    {
        // GET: Admin/Store
        CoffeeStore db = new CoffeeStore();
        public ActionResult Index()
        {
            List<Store> store = db.Stores.ToList();
            return View(store);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                Store Store = new Store();
                Store.Title = store.Title;
                Store.Subtitle = store.Subtitle;
                Store.Adress = store.Adress;
                Store.Phone = store.Phone;
                Store.Sunday = store.Sunday;
                Store.Munday = store.Munday;
                Store.Tuesday = store.Tuesday;
                Store.Wednesday = store.Wednesday;
                Store.Thursday = store.Thursday;
                Store.Friday = store.Friday;
                Store.Saturday = store.Saturday;

                db.Stores.Add(Store);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Update(int id)
        {
            Store store = db.Stores.Find(id);

            return View(store);
        }

        [HttpPost]
        public ActionResult Update(Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Store store = db.Stores.Find(id);

            if (store != null)
            {
                db.Stores.Remove(store);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}