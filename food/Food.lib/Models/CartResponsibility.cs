using Food.lib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Models
{
    public class CartResponsibility : ICartResponsibility
    {
        FoodContext Db = new FoodContext();

        public void AddOderDetail(List<OrderDetail> orderDetails)
        {
            Db.OrderDetails.AddRange(orderDetails);
            Db.SaveChanges();
        }

        public Order AddOrder(Customer customer)
        {
            Order order = new Order();
            order.CustomerId = customer.Id;
            order.HadSold = false;
            order.Cancelled = false;
            order.Shipped = false;
            order.OrderDate = DateTime.Now;
            Db.Orders.Add(order);
            Db.SaveChanges();
            return order;
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            return Db.Products.Where(p => p.DisContinued != true).ToList();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            Customer Check = Db.Customers.SingleOrDefault(p=>p.PhoneNumber==customer.PhoneNumber);
            if (Check!=null)
            {
                Check.Name = customer.Name;
                Check.PostalCode = customer.PostalCode;
                Check.Address = customer.Address;
                Db.SaveChanges();
            }
            else
            {
                Db.Customers.Add(customer);
                Db.SaveChanges();
                Check = customer;
            }
            return Check;
        }
    }
}
