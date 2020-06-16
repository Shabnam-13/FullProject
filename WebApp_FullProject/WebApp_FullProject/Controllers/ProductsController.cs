using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_FullProject.DAL;
using WebApp_FullProject.ViewModels;

namespace WebApp_FullProject.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        CoffeeStore db = new CoffeeStore();

        public ActionResult Index()
        {
            Vmodels model = new Vmodels();
            model.pageSetting = db.pageSettings.FirstOrDefault(l => l.Logo == "Start bootstrap");
            model.section = db.Sections.FirstOrDefault(p => p.Page == "Products");
            model.sections = db.Sections.ToList();
            return View(model);
        }
    }
}