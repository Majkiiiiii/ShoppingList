using System.Collections.ObjectModel;
using System.Linq;
using ShoppingListV3.Models;
using ShoppingListV3.Services;
using ShoppingListV3.Views;

namespace ShoppingListV3.ViewModels
{
    public class ProductViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>();
            LoadProducts();
        }

        public void AddProduct(string name, int quantity, string unit, bool isBought)
        {
            var newProduct = new Product
            {
                Name = name,
                Quantity = quantity,
                Unit = unit,
                IsBought = isBought
            };

            Products.Add(newProduct);
            LoadProducts();
        }

        public void SaveProducts()
        {
            ProductService.SaveProductsToJson(new List<Product>(Products));
            LoadProducts();
        }

        public void LoadProducts()
        {
            var products = ProductService.LoadProductsFromJson();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }



        public Product? FindProductByName(string name)
        {
            LoadProducts();
            return Products.FirstOrDefault(product => product.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
