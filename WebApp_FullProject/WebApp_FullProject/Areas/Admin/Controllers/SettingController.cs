using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebApp_FullProject.DAL;
using WebApp_FullProject.Models;

namespace WebApp_FullProject.Areas.Admin.Controllers
{
    public class SettingController : Controller
    {
        // GET: Admin/Setting
        CoffeeStore db = new CoffeeStore();
        public string oldImage;
        public string oldPath;

        public ActionResult Index()
        {
            List<PageSettings> settings = db.pageSettings.ToList();

            return View(settings);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PageSettings settings)
        {
            if (ModelState.IsValid)
            {
                PageSettings pageSettings = new PageSettings();
                pageSettings.Logo = settings.Logo;
                pageSettings.Title = settings.Title;
                pageSettings.Subtitle = settings.Subtitle;
                pageSettings.Copyright = settings.Copyright;

                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + settings.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads"), imageName);

                settings.ImageFile.SaveAs(imagePath);
                pageSettings.BgImage = imageName;

                db.pageSettings.Add(pageSettings);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Update(int id)
        {
            PageSettings settings = db.pageSettings.Find(id);

            return View(settings);
        }

        [HttpPost]
        public ActionResult Update(PageSettings settings)
        {
            if (ModelState.IsValid)
            {

                    oldImage = settings.BgImage;
                    oldPath = Path.Combine(Server.MapPath("~/Uploads"), oldImage);
                
                if (settings.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + settings.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads"), imageName);

                    System.IO.File.Delete(oldPath);
                    settings.ImageFile.SaveAs(imagePath);

                    settings.BgImage = imageName;
                }
                else
                {
                    settings.BgImage = oldImage;
                }

                db.Entry(settings).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            PageSettings settings = db.pageSettings.Find(id);
            if (settings.BgImage != null)
            {
                string oldImage = settings.BgImage;
                string oldPath = Path.Combine(Server.MapPath("~/Uploads"), oldImage);

                System.IO.File.Delete(oldPath);
            }
            db.pageSettings.Remove(settings);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}