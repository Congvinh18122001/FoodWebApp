using Food.lib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Models.AdminModel
{
   public  interface IOrderApprovalResponsibility
    {
        List<Order> GetOrders();
        Order GetOrder(int id);
        void UpdateOrder(Order order);
    }
}
