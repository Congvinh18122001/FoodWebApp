using Food.lib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Models
{
    public interface IServiceResponsibility
    {
         List<Product> GetProducts() ;
        List<Category> GetCategories();
    }
}
