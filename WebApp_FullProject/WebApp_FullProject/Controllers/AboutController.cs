using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_FullProject.DAL;
using WebApp_FullProject.ViewModels;

namespace WebApp_FullProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        CoffeeStore db = new CoffeeStore();
        public ActionResult Index()
        {
            Vmodels model = new Vmodels();
            model.pageSetting = db.pageSettings.FirstOrDefault(l => l.Logo == "Start bootstrap");
            model.section = db.Sections.FirstOrDefault(p => p.Page == "About");
            return View(model);
        }
    }
}