namespace ShoppingListV3.Views;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using ShoppingListV3.Models;
using ShoppingListV3.ViewModels;

public partial class ProductView : ContentView
{
    private ProductViewModel viewModel;
    public ObservableCollection<Product> Products { get; set; }

    public ProductView()
    {
        InitializeComponent();
        viewModel = new ProductViewModel();
        Products = new ObservableCollection<Product>();
        BindingContext = viewModel;
        viewModel.LoadProducts();
    }

    public void OnDecreaseQuantityClicked(object sender, EventArgs e)
    {
        if (BindingContext is Product product)
        {
            var productToUpdate = viewModel.FindProductByName(product.Name);
            if (productToUpdate != null && productToUpdate.Quantity > 0)
            {
                product.Quantity--;
                productToUpdate.Quantity--;
                viewModel.SaveProducts();
                productToUpdate = null;
                viewModel.LoadProducts();
            }
        }
    }

    public void OnIncreaseQuantityClicked(object sender, EventArgs e)
    {
        if (BindingContext is Product product)
        {
            var productToUpdate = viewModel.FindProductByName(product.Name);
            if (productToUpdate != null)
            {
                product.Quantity++;
                productToUpdate.Quantity++;
                viewModel.SaveProducts();
                productToUpdate = null;
                viewModel.LoadProducts();
            }
        }
    }
    public void OnDeleteProductClicked(object sender, EventArgs e)
    {
        if (BindingContext is Product product)
        {
            var productToRemove = viewModel.FindProductByName(product.Name);
            if (productToRemove != null)
            {
                viewModel.Products.Remove(productToRemove);
                viewModel.SaveProducts();
                viewModel.LoadProducts();
            }
            this.IsVisible = false;
        }
    }

    public void OnQuantityTextChanged(object sender, TextChangedEventArgs e)
    {
        if (BindingContext is Product product)
        {
            if (int.TryParse(e.NewTextValue, out int quantity))
            {
                product.Quantity = quantity;
                var productToUpdate = viewModel.FindProductByName(product.Name);
                if (productToUpdate != null)
                {
                    productToUpdate.Quantity = quantity;
                    viewModel.SaveProducts();
                }
            }
        }
    }

    public void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (BindingContext is Product product)
        {
            ProductName.TextDecorations = e.Value ? TextDecorations.Strikethrough : TextDecorations.None;
            ProductName.TextColor = e.Value ? Colors.Gray : Colors.White;

            product.IsBought = e.Value;
            var productToUpdate = viewModel.FindProductByName(product.Name);
            productToUpdate.IsBought = e.Value;
            viewModel.SaveProducts();
        }
    }
}
