using Food.lib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Models.AdminModel
{
   public interface IProductResponsibility
    {
        List<Product> GetProducts();
        Product GetProduct(int Id);
        List<Supplier> GetSuppliers();
        List<Category> GetCategories();
        void AddProduct(Product product);
        void UpdateProduct(List<Product> products);
    }
}
