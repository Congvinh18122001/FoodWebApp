using Food.lib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Models.AdminModel
{
    public class ProductResponsibility : IProductResponsibility
    {
        FoodContext Db = new FoodContext();

        public void AddProduct(Product product)
        {
            Db.Products.Add(product);
            Db.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return Db.Categories.ToList();
        }

        public Product GetProduct(int Id)
        {
            return Db.Products.SingleOrDefault(p=>p.Id==Id);

        }

        public List<Product> GetProducts()
        {
            return Db.Products.ToList();
        }

        public List<Supplier> GetSuppliers()
        {
            return Db.Suppliers.ToList();
        }

        public void UpdateProduct(List<Product> products)
        {
            foreach (var item in products)
            {
                Product product = Db.Products.SingleOrDefault(p=>p.Id==item.Id);
                if (product!=null)
                {
                    product.Inventory += item.Inventory;
                    product.UnitsPrice = item.UnitsPrice;
                }
            }
            Db.SaveChanges();
        }
    }
}
