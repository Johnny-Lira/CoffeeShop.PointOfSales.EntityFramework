using CoffeeShop.PointOfSales.EntityFramework;
using Spectre.Console;

var isRunning = true;

while (isRunning)
{
    var option = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOptions>()
            .Title("What do you want to do?")
            .PageSize(10)
            .AddChoices(MenuOptions.AddProduct,
            MenuOptions.RemoveProduct,
            MenuOptions.UpdateProduct,
            MenuOptions.ViewProduct,
            MenuOptions.ViewAllProducts,
            MenuOptions.Quit)
    );

    switch (option)
    {
        case MenuOptions.AddProduct:
            ProductController.AddProduct();
            break;
        case MenuOptions.RemoveProduct:
            ProductController.DeleteProduct();
            break;
        case MenuOptions.UpdateProduct:
            ProductController.UpdateProduct();
            break;
        case MenuOptions.ViewProduct:
            var product = ProductService.GetProductOptionInput();
            UserInterface.ShowProduct(product);
            break;
        case MenuOptions.ViewAllProducts:
            var products = ProductController.GetProducts();
            UserInterface.ShowProductTable(products);
            break;
        case MenuOptions.Quit:
            isRunning = false;
            break;
        default:
            break;
    }
}

enum MenuOptions
{
    AddProduct,
    RemoveProduct,
    UpdateProduct,
    ViewProduct,
    ViewAllProducts,
    Quit
};

