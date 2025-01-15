using ShoppingListV3.ViewModels;
using ShoppingListV3.Models;
namespace ShoppingListV3.Views;

public partial class ShoppingListPage : ContentPage
{
    private ProductViewModel viewModel;

    public ShoppingListPage()
    {
        InitializeComponent();
        viewModel = (ProductViewModel)BindingContext;
        viewModel.LoadProducts();
    }

    private async void OnNavigateToAddProductPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddProductPage(viewModel));
    }
}