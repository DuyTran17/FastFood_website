using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ShopCart cart = Session["Cart"] as ShopCart;
            ViewData["Product"] = cart;
            return View();
        }
        public ActionResult Add(int Product_ID)
        {
            ShopCart cart = Session["Cart"] as ShopCart;
            cart.AddProduct(Product_ID, 1);
            Session["GioHang"] = cart;
            return RedirectToAction("Index");
        }
        public ActionResult Decrease(int Product_ID)
        {
            ShopCart cart = Session["Cart"] as ShopCart;
            cart.rdcProduct(Product_ID);
            Session["Cart"] = cart;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Product_ID)
        {
            ShopCart cart = Session["Cart"] as ShopCart;
            cart.rmvProduct(Product_ID);
            Session["Cart"] = cart;
            return RedirectToAction("Index");
        }
    }
}