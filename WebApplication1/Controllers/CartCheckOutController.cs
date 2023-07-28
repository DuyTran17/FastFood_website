using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;
using System.Globalization;


namespace WebApplication1.Controllers
{
    public class CartCheckOutController : Controller
    {
        // GET: CartCheckOut
        public ActionResult Index()
        {
            ShopCart sc = Session["Cart"] as ShopCart;
            ViewData["Product"] = sc;
            return View();
        }
        [HttpPost]
        public ActionResult SaveToDatabase()
        {
                Account ac = Session["Login"] as Account;
                Cart cart = new Cart();
                cart.Customer_id = 2;
                string x = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime date = DateTime.ParseExact(x, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                cart.Created_at = date;
                Do_An_CDTNKTPM1Entities db = new Do_An_CDTNKTPM1Entities();
                db.Carts.Add(cart);
                db.SaveChanges();             
                foreach(Cart i in Common.getCart())
                {
                if(i.Customer_id.Equals(2) && i.Created_at.Equals(date))
                {
                    ShopCart sc = Session["Cart"] as ShopCart;
                    foreach (CartDetail y in sc.ProductID.Values)
                    {
                        y.Cart_id = i.Cart_id;                      
                        db.CartDetails.Add(y);
                        db.SaveChanges();
                    }
                    
                }
                }
            return  RedirectToAction("Index", "Menu");
            
        }
    }
}