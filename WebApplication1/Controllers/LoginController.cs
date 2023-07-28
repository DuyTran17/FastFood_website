using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string acc, string pass)
        {
            foreach (Account i in Common.getAccout())
            {
                if (acc.Equals(i.UserName) && pass.Equals(i.Password))
                {
                    Session["Login"] = i;
                    return RedirectToAction("Index", "Menu");
                    break;
                }
            }

            return RedirectToAction("Index", "Login");
        }
    }
}