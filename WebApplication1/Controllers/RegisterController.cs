using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string acc , string pass)
        {
            
            foreach (Account i in Common.getAccout())
            {
                if (acc.Equals(i.UserName) )
                {
                   
                    return RedirectToAction("Index", "Menu");
                    break;
                }
                    Account x = new Account();
                    x.UserName = acc;
                    x.Password = pass;                                 
                    Do_An_CDTNKTPM1Entities db = new Do_An_CDTNKTPM1Entities();
                    db.Accounts.Add(x);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                break;                             
            }
            return RedirectToAction("Index", "Register"); ;
        }
        
    }
}