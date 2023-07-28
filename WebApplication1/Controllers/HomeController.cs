using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {  
            return View();
        }
        public ActionResult Add(int Product_ID)
        {
            ShopCart cart = Session["Cart"] as ShopCart;
            cart.AddProduct(Product_ID, 1);
            Session["GioHang"] = cart;
            return RedirectToAction("Index", "Home");
        }

    }
}