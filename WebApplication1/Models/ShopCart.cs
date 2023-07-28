using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ShopCart
    {
        public string CustomerID { set; get; }
        public DateTime CreatedAt { set; get; }
        
        public SortedList<int, CartDetail> ProductID { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public ShopCart()
        {
            this.CustomerID = "";
            this.CreatedAt = DateTime.Now;           
            this.ProductID = new SortedList<int, CartDetail>();
        }
        /// <summary>
        /// Kiểm tra giỏ Hàng trống
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return ProductID.Keys.Count == 0;
        }
        /// <summary>
        /// Thêm Sản phẩm vào giỏ hàng
        /// </summary>
        /// <param name="Product_ID"></param>
        /// <param name="Quanity"></param>
        public void AddProduct(int Product_ID, int Quanity)
        {
            if (ProductID.Keys.Contains(Product_ID))
            {
                CartDetail x = ProductID.Values[ProductID.IndexOfKey(Product_ID)];
                x.Quantity++;
            }
            else
            {
                CartDetail y = new CartDetail();
                y.Product_id = Product_ID;
                y.Quantity = Quanity;
                Product z = Common.GetProductbyID(Product_ID);
                y.Price = z.Price;
                ProductID.Add(Product_ID, y);
            }
        }
        /// <summary>
        /// Xóa sản phẩm khỏi giỏ Hàng(remove)
        /// </summary>
        public void rmvProduct(int Product_ID)
        {
            if (ProductID.Keys.Contains(Product_ID))
            {
                ProductID.Remove(Product_ID);
            }
        }
        /// <summary>
        /// Giảm số lượng sản phẩm(reduce)
        /// </summary>
        public void rdcProduct(int Product_ID)
        {
            if (ProductID.Keys.Contains(Product_ID))
            {
                CartDetail x = ProductID.Values[ProductID.IndexOfKey(Product_ID)];
                if (x.Quantity > 1)
                {
                    x.Quantity--;
                }
                else
                    rmvProduct(Product_ID);
            }
        }
        /// <summary>
        /// Tính tổng giá 1 món
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public long PriceProduct(CartDetail x)
        {
            return (long)((x.Price  * x.Quantity));
        }
        /// <summary>
        /// Tính tổng giá đơn hàng
        /// </summary>
        /// <returns></returns>
        public long totalPrice()
        {
            long Tt = 0;
            foreach (CartDetail x in ProductID.Values)
                Tt += PriceProduct(x);
            return Tt;
        }

    }
}
