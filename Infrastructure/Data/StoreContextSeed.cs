using System.Text.Json;
using Core.Entities;


namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.Products.Any())
        {
            var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");

            // convert to json
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            if (products == null) return;

             foreach (var item in products)
            {
                context.Products.Add(item);
            }

            await context.SaveChangesAsync();
        }

    }
}