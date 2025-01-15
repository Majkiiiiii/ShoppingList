using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ShoppingListV3.Models;

namespace ShoppingListV3.Services
{
    public static class ProductService
    {
        private static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "products.json");

        public static void SaveProductsToJson(List<Product> products)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(products, options);
            File.WriteAllText(FilePath, json);
        }

        public static List<Product> LoadProductsFromJson()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Product>>(json);
            }
            return new List<Product>();
        }
    }
}

