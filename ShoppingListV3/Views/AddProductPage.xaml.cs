using ShoppingListV3.ViewModels;
using ShoppingListV3.Models;
namespace ShoppingListV3.Views;

public partial class AddProductPage : ContentPage
{
    private ProductViewModel viewModel;

    public AddProductPage(ProductViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
    }

    private void OnAddProductClicked(object sender, EventArgs e)
    {
        string name = ProductNameEntry.Text;
        if (int.TryParse(ProductQuantityEntry.Text, out int quantity))
        {
            string unit = UnitPicker.SelectedItem?.ToString();
            bool isBought = false;

            viewModel.Products.Add(new Product { Name = name, Quantity = quantity, Unit = unit, IsBought = isBought });

            ProductNameEntry.Text = string.Empty;
            ProductQuantityEntry.Text = string.Empty;
            UnitPicker.SelectedIndex = -1;

            viewModel.SaveProducts();
            Navigation.PopAsync();
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid quantity", "OK");
        }
    }
}
