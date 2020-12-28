using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Food.lib.Models;
using Food.lib.Objects;
using PagedList;
namespace WebApplication.Controllers
{
    public class ServiceController : Controller
    {
        IServiceResponsibility service = new ServiceResponsibility();

        // GET: Service
        public ActionResult Index()
        {

            return View(service.GetProducts());
        }
        public ActionResult Supplier(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                return View(service.GetProducts().Where(p => p.ProductName == name));
            }
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int? id)
        {
            if (id.HasValue)
            {
                Product product = service.GetProducts().Single(p=>p.Id==id.Value);
                IEnumerable<Product> products = service.GetProducts().Where(p => p.SupplierId == product.SupplierId) ;
                ViewBag.productsOfSupplier = products ;
                return View(product);
            }
            return RedirectToAction("Index");

        }


    }
}