using Food.lib.Models;
using Food.lib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        ICartResponsibility responsibility = new CartResponsibility();
        public List<CartItemModel> GetCart()
        {
            List<CartItemModel> itemCarts = Session["Cart"] as List<CartItemModel>;
            if (itemCarts == null)
            {
                itemCarts = new List<CartItemModel>();
                Session["Cart"] = itemCarts;
            }
            return itemCarts;
        }
        public ActionResult AddToCart(int? ProductId,string urlString)
        {

            if (ProductId.HasValue)
            {
                Product FindProduct = responsibility.GetProducts().SingleOrDefault(p=>p.Id==ProductId.Value);
                if (FindProduct==null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                List<CartItemModel> itemCarts = GetCart();
                CartItemModel CheckCart = itemCarts.SingleOrDefault(p=>p.Product.Id==ProductId);
                if (CheckCart !=null)
                {
                    if (FindProduct.Inventory<=CheckCart.Quarity)
                    {
                        return RedirectToAction("Notification", "Home", new { notify = "Không đủ hàng" });
                    }
                    CheckCart.Quarity++;
                    CheckCart.TotalPrice = CheckCart.Quarity * CheckCart.Product.UnitsPrice;
                    return Redirect(urlString);
                }
                CartItemModel cartItem = new CartItemModel(FindProduct);
                itemCarts.Add(cartItem);
                return Redirect(urlString);

            }
            return RedirectToAction("Index", "Service");
        }
        public int SumQuarity()
        {
            List<CartItemModel> itemCarts = Session["Cart"] as List<CartItemModel>;
            if (itemCarts == null)
            {
                return 0;
            }
            return itemCarts.Sum(p => p.Quarity);

        }
        public decimal SumPrice()
        {
            List<CartItemModel> itemCarts = Session["Cart"] as List<CartItemModel>;
            if (itemCarts == null)
            {
                return 0;
            }
            return itemCarts.Sum(p => (decimal)p.TotalPrice);
        }
        public ActionResult CartPatial()
        {
            //ViewBag.SumQuarity = SumQuarity();
            return View();
        }
        public ActionResult ShowCart()
        {
            List<CartItemModel> itemCarts = Session["Cart"] as List<CartItemModel>;
            if (itemCarts !=null)
            {
                return View(itemCarts);

            }
            return RedirectToAction("Notification", "Home", new { notify = "Cart IsEmpty" });

        }
    }
}