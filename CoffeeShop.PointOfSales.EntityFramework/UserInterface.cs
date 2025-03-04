using CoffeeShop.PointOfSales.EntityFramework.Models;
using CoffeeShop.PointOfSales.EntityFramework.Services;
using Spectre.Console;

namespace CoffeeShop.PointOfSales.EntityFramework
{
    static internal class UserInterface
    {
        static internal void MainMenu()
        {
            var isRunning = true;

            while (isRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<MenuOptions>()
                        .Title("What do you want to do?")
                        .PageSize(10)
                        .AddChoices(
                            MenuOptions.AddCategory,
                            MenuOptions.ViewAllCategories,
                            MenuOptions.AddProduct,
                            MenuOptions.DeleteProduct,
                            MenuOptions.UpdateProduct,
                            MenuOptions.ViewProduct,
                            MenuOptions.ViewAllProducts,
                            MenuOptions.Quit)
                );

                switch (option)
                {
                    case MenuOptions.AddCategory:
                        CategoryService.InsertCategory();
                        break;
                    case MenuOptions.ViewAllCategories:
                        CategoryService.GetCategories();
                        break;
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
        }
        static internal void ShowProduct(Product product)
        {
            var panel = new Panel($@"Id: {product.ProductId} Name: {product.Name}")
            {
                Header = new PanelHeader("Product Info"),
                Padding = new Padding(2, 2, 2, 2)
            };

            AnsiConsole.Write(panel);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        static internal void ShowProductTable(List<Product> products)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");
            table.AddColumn("Price");

            foreach (var product in products)
            {
                table.AddRow(product.ProductId.ToString(), product.Name, product.Price.ToString());
            }
            AnsiConsole.Write(table);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        static internal void ShowCategoryTable(List<Category> categories)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Category");

            foreach (var category in categories)
            {
                table.AddRow(
                    category.Id.ToString(),
                    category.Name);
            }
            AnsiConsole.Write(table);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
