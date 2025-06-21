using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Services
{
    public class ProductService
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product) => _products.Add(product);

        public List<Product> Search (string keyword)
        {
            return _products.Where(p =>
                p.Name.ToLower().Contains(keyword.ToLower()) ||
                p.Category.ToLower().Contains(keyword.ToLower())).ToList();
        }

        public List<Product> GetAll() => _products;
    }
}
