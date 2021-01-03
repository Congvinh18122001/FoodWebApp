using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Food.lib.Models.AdminModel;
using Food.lib.Objects;
namespace WebApplication.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        IProductResponsibility responsibility = new ProductResponsibility();
        // GET: Admin/Product
        public ActionResult Index()
        {

            return View(responsibility.GetProducts());
        }
        public ActionResult Details(int? Id)
        {
            if (Id.HasValue)
            {
                Product product = responsibility.GetProduct(Id.Value);
                return View(product);
            }
            return RedirectToAction("Indexs");
        }
        public ActionResult AddProduct()
        {
            ViewBag.Products = responsibility.GetProducts();
            return View();
        }
        public ActionResult SaveProduct(List<Product> products)
        {
            if (products!=null)
            {
                responsibility.UpdateProduct(products);
            }
            return RedirectToAction("Index");
        }
        public  ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(responsibility.GetCategories(), "Id", "CategoryName");
            ViewBag.SupplierId = new SelectList(responsibility.GetSuppliers(), "Id", "SupplierName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (product!=null)
            {
                responsibility.AddProduct(product);
            }
            return RedirectToAction("Index");
        }



    }
}