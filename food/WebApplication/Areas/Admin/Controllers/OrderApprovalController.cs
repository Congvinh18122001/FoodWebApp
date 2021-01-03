using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Food.lib.Models.AdminModel;
using Food.lib.Objects;

namespace WebApplication.Areas.Admin.Controllers
{
    public class OrderApprovalController : Controller
    {
        IOrderApprovalResponsibility responsibility = new OrderApprovalResponsibility();
        // GET: Admin/OrderApproval
        public ActionResult Index()
        {
            return View(responsibility.GetOrders().Where(p => p.HadSold != true && p.Cancelled != true && p.Shipped != true));
        }
        public ActionResult HasSold()
        {
            return View("Index",responsibility.GetOrders().Where(p=>p.HadSold==true&&p.Cancelled!=true&&p.Shipped!=true));
        }
        public ActionResult Done()
        {
            return View("Index", responsibility.GetOrders().Where(p => p.HadSold == true && p.Cancelled != true && p.Shipped == true));
        }
        [HttpGet]
        public ActionResult OrderApproval(int? id)
        {
            if (id.HasValue)
            {
                Order order = responsibility.GetOrder(id.Value);
                return View(order);
            }

            return RedirectToAction("Index");
        }
        public ActionResult UpdateOrder(Order order)
        {
            if (order!=null)
            {
                responsibility.UpdateOrder(order);
            }
            return RedirectToAction("Index");
        }
    }
}