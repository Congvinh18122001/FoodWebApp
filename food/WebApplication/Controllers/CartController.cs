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
        public ActionResult AddToCart(int? ProductId, string urlString)
        {

            if (ProductId.HasValue)
            {
                Product FindProduct = responsibility.GetProducts().SingleOrDefault(p => p.Id == ProductId.Value);
                if (FindProduct == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                List<CartItemModel> itemCarts = GetCart();
                CartItemModel CheckCart = itemCarts.SingleOrDefault(p => p.Product.Id == ProductId);
                if (CheckCart != null)
                {
                    if (FindProduct.Inventory <= CheckCart.Quarity)
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
            if (Session["Cart"] != null)
            {
                List<CartItemModel> itemCarts = Session["Cart"] as List<CartItemModel>;
                if (itemCarts == null)
                {
                    return 0;
                }
                return itemCarts.Sum(p => p.Quarity);
            }
            return 0;

        }
        public decimal SumPrice()
        {
            if (Session["Cart"] != null)
            {
                List<CartItemModel> itemCarts = Session["Cart"] as List<CartItemModel>;
                if (itemCarts == null)
                {
                    return 0;
                }
                return itemCarts.Sum(p => (decimal)p.TotalPrice);
            }
            return 0;
        }
        public PartialViewResult CartPatial()
        {
            ViewBag.SumQuarity = SumQuarity();
            return PartialView();
        }
        public ActionResult ShowCart()
        {
            List<CartItemModel> itemCarts = Session["Cart"] as List<CartItemModel>;
            if (itemCarts != null)
            {
                return View(itemCarts);

            }
            return RedirectToAction("Notification", "Home", new { notify = "Cart IsEmpty" });

        }
        public ActionResult SaveOrder(Customer customer)
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("ShowCart");
            }
            List<CartItemModel> itemCarts = GetCart();
            Customer cus = responsibility.UpdateCustomer(customer);
            Order order = responsibility.AddOrder(cus);

            List<OrderDetail> OrderDetails = new List<OrderDetail>();
            foreach (var item in itemCarts)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderId = order.Id;
                orderDetail.ProductId = item.Product.Id;
                orderDetail.Quantity = item.Quarity;
                orderDetail.UnitsPrice = item.Product.UnitsPrice;
                OrderDetails.Add(orderDetail);
            }
            responsibility.AddOderDetail(OrderDetails);
            Session["Cart"] = null;
            return RedirectToAction("ShowCart");
        }
    }
}