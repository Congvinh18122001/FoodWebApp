using Food.lib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Models
{
     public class ServiceResponsibility : IServiceResponsibility
    {
        FoodContext Db = new FoodContext();

        public List<Category> GetCategories()
        {
            return Db.Categories.ToList();
        }

        public List<Product> GetProducts()
        {
            return Db.Products.Where(p=>p.DisContinued!=true).ToList();
        }
    }
}
