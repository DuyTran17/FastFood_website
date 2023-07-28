using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Common
    {
        private static DbContext dbContext = new DbContext("name=Do_An_CDTNKTPM1Entities");
        /// <summary>
        /// Lấy danh sách các món tong database
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetProducts()
        {
            List<Product> l = new List<Product>() ;
            l = dbContext.Set<Product>().ToList<Product>();
            return l;
        }/// <summary>
        /// Lấy danh sách các món theo catogeries
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetProductsbyCatogeries(int Category_ID)
        {
            List<Product> l = new List<Product>();
            l = dbContext.Set<Product>().Where(x => x.Category_id.Equals(Category_ID)).ToList<Product>();
            return l;
        }
        /// <summary>
        /// Lấy sản phẩm theo ID
        /// </summary>
        /// <returns></returns>
        public static Product GetProductbyID(int Product_ID)
        {
            return dbContext.Set<Product>().Find(Product_ID);
        }
        /// <summary>
        /// Lấy tên sản phẩm theo mã ID
        /// </summary>
        public static string getNameProductByID(int Product_ID)
        {
            return dbContext.Set<Product>().Find(Product_ID).Product_name;
        }
        /// <summary>
        /// Lấy ảnh sản phẩm theo mã ID
        /// </summary>
        public static string getImgProductByID(int Product_ID)
        {
            return dbContext.Set<Product>().Find(Product_ID).Images;
        }
        /// <summary>
        /// Lấy danh sách Accout
        /// </summary>
        /// <returns></returns>
        public static List<Account> getAccout()
        {
            List<Account> l = new List<Account>();
            l = dbContext.Set<Account>().ToList<Account>();
            return l;
        }
        public static List<Cart> getCart()
        {
            List<Cart> l = new List<Cart>();
            l = dbContext.Set<Cart>().ToList<Cart>();
            return l;
        }
    }
}