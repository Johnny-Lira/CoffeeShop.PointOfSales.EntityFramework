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
            MenuOptions.DeleteProduct,
            MenuOptions.UpdateProduct,
            MenuOptions.ViewProduct,
            MenuOptions.ViewAllProducts,
            MenuOptions.Quit)
    );

    switch (option)
    {
        case MenuOptions.AddProduct:
            ProductService.InsertProduct();
            break;
        case MenuOptions.DeleteProduct:
            ProductService.DeleteProduct();
            break;
        case MenuOptions.UpdateProduct:
            ProductService.UpdateProduct();
            break;
        case MenuOptions.ViewProduct:
            ProductService.GetProduct();
            break;
        case MenuOptions.ViewAllProducts:
            ProductService.GetProducts();
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
    DeleteProduct,
    UpdateProduct,
    ViewProduct,
    ViewAllProducts,
    Quit
};

