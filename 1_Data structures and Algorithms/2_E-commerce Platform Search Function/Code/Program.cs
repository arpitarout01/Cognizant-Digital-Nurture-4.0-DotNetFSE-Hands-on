using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Models;
using ECommerceConsoleApp.Services;

namespace ECommerceConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var productService = new ProductService();
            var orderService = new OrderService();
            var user = new User { Id = 1, Username = "Arpita", Email = "arpitarout132@gmail.com" };

            // Preload products
            productService.AddProduct(new Product { Id = 1, Name = "iPhone 15", Category = "Electronics", Price = 82999.00, Stock = 10 });
            productService.AddProduct(new Product { Id = 2, Name = "Samsung S24", Category = "Electronics", Price = 74999.99, Stock = 5 });
            productService.AddProduct(new Product { Id = 3, Name = "Nike Air Max", Category = "Footwear", Price = 8999.99, Stock = 8 });

            while (true)
            {
                Console.WriteLine("\nWelcome to E-Commerce Console App!");
                Console.WriteLine("1. View All Products");
                Console.WriteLine("2. Search Product");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    var allProducts = productService.GetAll();
                    foreach (var p in allProducts)
                    {
                        Console.WriteLine($"{p.Id}: {p.Name} - {p.Category} - Rupees {p.Price}");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter keyword to search: ");
                    string keyword = Console.ReadLine();
                    var results = productService.Search(keyword);
                    if (results.Count > 0)
                    {
                        foreach (var p in results)
                        {
                            Console.WriteLine($"{p.Id}: {p.Name} - {p.Category} - Rupees {p.Price}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No products found.");
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Enter Product IDs to order (comma-separated): ");
                    string[] ids = Console.ReadLine().Split(',');
                    var selectedProducts = new List<Product>();

                    foreach (string idStr in ids)
                    {
                        if (int.TryParse(idStr.Trim(), out int id))
                        {
                            var product = productService.GetAll().Find(p => p.Id == id);
                            if (product != null)
                            {
                                selectedProducts.Add(product);
                            }
                            else
                            {
                                Console.WriteLine($"Product with ID {id} not found.");
                            }
                        }
                    }

                    if (selectedProducts.Count > 0)
                    {
                        orderService.PlaceOrder(user, selectedProducts);
                        Console.WriteLine("Order placed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No valid products selected.");
                    }
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Exiting... ");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
    }
}
