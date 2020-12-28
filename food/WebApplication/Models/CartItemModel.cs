using Food.lib.Objects;
using Food.lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CartItemModel
    {
        public Product Product { get; set; }
        public int Quarity { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        ICartResponsibility Responsibility = new CartResponsibility();
        public CartItemModel(Product Product)
        {
            this.Product = Product;
            this.Quarity = 1;
            this.TotalPrice = Quarity * Product.UnitsPrice ;
        }
    }
}