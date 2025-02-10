using Spectre.Console;

namespace CoffeeShop.PointOfSales.EntityFramework
{
    internal class ProductService
    {
        static internal Product GetProductOptionInput()
        {
            var products = ProductController.GetProducts();
            var productsArray = products.Select(p => p.Name).ToArray();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a product")
                    .AddChoices(productsArray)
            );

            var id = products.Single(x => x.Name == option).Id;
            var product = ProductController.GetProductById(id);

            return product;
        }
    }
}
