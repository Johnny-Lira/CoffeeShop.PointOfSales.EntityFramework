using CoffeeShop.PointOfSales.EntityFramework.Controllers;
using CoffeeShop.PointOfSales.EntityFramework.Models;
using Spectre.Console;

namespace CoffeeShop.PointOfSales.EntityFramework.Services
{
    internal class ProductService
    {
        internal static void InsertProduct()
        {
            var product = new Product()
            {
                Name = AnsiConsole.Ask<string>("Enter the name of the product"),
                Price = AnsiConsole.Ask<decimal>("Enter the price of product")
            };
            ProductController.AddProduct(product);

        }

        internal static void DeleteProduct()
        {
            var product = GetProductOptionInput();

            if (product != null)
            {
                var confirm = AnsiConsole.Confirm("Are you sure you want to delete this product?");
                if (!confirm)
                    return;

                ProductController.DeleteProduct(product);
            }
        }

        internal static void GetProducts()
        {
            var products = ProductController.GetProducts();
            UserInterface.ShowProductTable(products);
        }

        internal static void GetProduct()
        {
            var product = GetProductOptionInput();
            if (product != null)
                UserInterface.ShowProduct(product);
            else
                AnsiConsole.MarkupLine("[red]Product not found[/]");
        }

        internal static void UpdateProduct()
        {
            var product = GetProductOptionInput();
            if (product != null)
            {
                product.Name = AnsiConsole.Confirm("Update name?")
                    ? product.Name = AnsiConsole.Ask<string>("Enter the new name of the product")
                    : product.Name;

                product.Price = AnsiConsole.Confirm("Update price?")
                    ? product.Price = AnsiConsole.Ask<decimal>("Enter the new price of the product")
                    : product.Price;
                ProductController.UpdateProduct(product);
            }
            else
                AnsiConsole.MarkupLine("[red]Product not found[/]");
        }

        static private Product? GetProductOptionInput()
        {
            var products = ProductController.GetProducts();
            var productsArray = products.Select(p => p.Name).ToList();
            productsArray.Add("Back");

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a product")
                    .AddChoices(productsArray)
            );

            if (option.Equals("Back"))
            {
                return null;
            }

            var id = products.Single(x => x.Name == option).ProductId;
            var product = ProductController.GetProductById(id);

            return product;
        }
    }
}
