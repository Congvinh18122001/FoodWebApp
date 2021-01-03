using Food.lib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Models
{
   public interface ICartResponsibility
    {
        List<Product> GetProducts();
        List<Category> GetCategories();
        Customer UpdateCustomer(Customer customer);
        Order AddOrder(Customer customer);
        void AddOderDetail(List<OrderDetail> orderDetails);
    }
}
