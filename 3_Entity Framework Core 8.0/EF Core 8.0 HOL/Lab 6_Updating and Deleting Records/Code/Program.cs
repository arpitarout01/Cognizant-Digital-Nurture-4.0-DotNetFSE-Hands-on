using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        if (!await context.Categories.AnyAsync())
        {
            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };

            await context.Categories.AddRangeAsync(electronics, groceries);

            var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
            var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

            await context.Products.AddRangeAsync(product1, product2);
            await context.SaveChangesAsync();

            Console.WriteLine("Initial data inserted successfully.");
        }
        else
        {
            Console.WriteLine("Data already exists. Skipping seeding.");
        }

        Console.WriteLine("\nAll Products:");
        var products = await context.Products.ToListAsync();
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - ₹{p.Price}");

        var productById = await context.Products.FindAsync(1);
        Console.WriteLine($"\nFound by ID = 1: {productById?.Name}");

        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Most Expensive: {expensive?.Name}");

        var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
        if (product != null)
        {
            product.Price = 70000;
            await context.SaveChangesAsync();
            Console.WriteLine($"\nUpdated '{product.Name}' price to ₹{product.Price}");
        }

        var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
        if (toDelete != null)
        {
            context.Products.Remove(toDelete);
            await context.SaveChangesAsync();
            Console.WriteLine($"Deleted '{toDelete.Name}' from the database.");
        }

        Console.WriteLine("\nProducts with Price > ₹1000 (High to Low):");
        var filtered = await context.Products
            .Where(p => p.Price > 1000)
            .OrderByDescending(p => p.Price)
            .ToListAsync();

        foreach (var p in filtered)
        {
            Console.WriteLine($"- {p.Name} → ₹{p.Price}");
        }

        Console.WriteLine("\nProjected Product DTOs:");
        var productDTOs = await context.Products
            .Select(p => new { p.Name, p.Price })
            .ToListAsync();

        foreach (var dto in productDTOs)
        {
            Console.WriteLine($"- {dto.Name} (₹{dto.Price})");
        }


        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}