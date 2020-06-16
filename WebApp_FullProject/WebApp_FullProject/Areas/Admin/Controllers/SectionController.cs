using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_FullProject.DAL;
using WebApp_FullProject.Models;

namespace WebApp_FullProject.Areas.Admin.Controllers
{
    public class SectionController : Controller
    {
        // GET: Admin/Section
        CoffeeStore db = new CoffeeStore();
        public string oldPath;
        public string oldImage;

        public ActionResult Index()
        {
            List<Sections> sections = db.Sections.ToList();
            return View(sections);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sections section)
        {
            if (ModelState.IsValid)
            {
                Sections Sections = new Sections();
                Sections.Title = section.Title;
                Sections.Subtitle = section.Subtitle;
                Sections.Content = section.Content;
                Sections.Page = section.Page;
                Sections.CreateDate = section.CreateDate;

                if (section.ImageFile != null)
                {
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + section.ImageFile.FileName;
                string imagepath = Path.Combine(Server.MapPath("~/Uploads"), imageName);

                section.ImageFile.SaveAs(imagepath);
                Sections.Image = imageName;
                }

                db.Sections.Add(Sections);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Update(int id)
        {
            Sections sections = db.Sections.Find(id);

            return View(sections);
        }

        [HttpPost]
        public ActionResult Update(Sections sections)
        {
            if (ModelState.IsValid)
            {
                if (sections.Image != null)
                {
                    oldImage = sections.Image;
                    oldPath = Path.Combine(Server.MapPath("~/Uploads"), oldImage);
                }
                if (sections.ImageFile != null)
                {  
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + sections.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads"), imageName);

                    System.IO.File.Delete(oldPath);
                    sections.ImageFile.SaveAs(imagePath);

                    sections.Image = imageName;
                }
                else
                {
                    sections.Image = oldImage;
                }

                db.Entry(sections).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Sections sections = db.Sections.Find(id);
            if (sections.Image != null)
            {
                string oldImage = sections.Image;
                string oldPath = Path.Combine(Server.MapPath("~/Uploads"), oldImage);

                System.IO.File.Delete(oldPath);
            }
            db.Sections.Remove(sections);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}