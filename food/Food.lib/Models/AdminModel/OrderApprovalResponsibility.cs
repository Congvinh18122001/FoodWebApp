using Food.lib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Models.AdminModel
{
   public  class OrderApprovalResponsibility : IOrderApprovalResponsibility
    {
        FoodContext Db = new FoodContext();

        public Order GetOrder(int id)
        {
            return Db.Orders.SingleOrDefault(p=>p.Id==id);
        }

        public List<Order> GetOrders()
        {
            return Db.Orders.ToList();
        }

        public void UpdateOrder(Order order)
        {
            Order GetOder = Db.Orders.SingleOrDefault(p=>p.Id==order.Id);
            GetOder.HadSold = order.HadSold;
            GetOder.Cancelled = order.Cancelled;
            if (GetOder.Shipped==false&&order.Shipped==true)
            {
                GetOder.ShippedDate = DateTime.Now;
                foreach (var item in GetOder.OrderDetails)
                {
                    Product product = Db.Products.SingleOrDefault(p=>p.Id==item.ProductId);
                    product.Inventory = product.Inventory - item.Quantity;
                }
            }
            GetOder.Shipped = order.Shipped;

            Db.SaveChanges();

        }
    }
}
