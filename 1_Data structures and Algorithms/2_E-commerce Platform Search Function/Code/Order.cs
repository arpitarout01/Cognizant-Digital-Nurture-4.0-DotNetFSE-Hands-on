using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceConsoleApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Product> Products { get; set; }
        public double TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
