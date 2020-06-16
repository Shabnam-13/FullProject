using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_FullProject.DAL;
using WebApp_FullProject.ViewModels;

namespace WebApp_FullProject.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        CoffeeStore db = new CoffeeStore();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                Models.Admin admin = db.Admins.FirstOrDefault(a => a.Email == login.Email);
                if (admin != null)
                {
                    if (admin.Password == login.Password)
                    {
                        Session["Admin"]= admin;
                        Session["AminId"] = admin.Id;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Password Incorrect");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Email Incorrect");
                }
            }
            return View(login);
        }
    }
}