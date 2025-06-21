using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Services
{
    public class OrderService
    {
        private List<Order> _orders = new List<Order>();

        public void PlaceOrder(User user, List<Product> products)
        {
            var order = new Order
            {
                Id = _orders.Count + 1,
                UserId = user.Id,
                Products = products,
                TotalAmount = products.Sum(p => p.Price),
                OrderDate = DateTime.Now
            };

            _orders.Add(order);
        }

        public List<Order> GetOrderByUserId(int userId)
        {
            return _orders.Where(o => o.UserId == userId).ToList();
        }
    }
}
