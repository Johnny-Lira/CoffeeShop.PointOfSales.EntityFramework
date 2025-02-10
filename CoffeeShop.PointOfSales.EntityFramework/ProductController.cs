
using Spectre.Console;

namespace CoffeeShop.PointOfSales.EntityFramework
{
    internal class ProductController
    {

        internal static void AddProduct()
        {
            var name = AnsiConsole.Ask<string>("Enter the name of the product");
            using var db = new ProductsContext();
            db.Add(new Product { Name = name });
            db.SaveChanges();
        }

        internal static void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        internal static Product GetProductById( int id)
        {
            using var db = new ProductsContext();
            var product = db.Products.SingleOrDefault(p => p.Id == id);
            return product;
        }

        internal static void UpdateProduct()
        {
            throw new NotImplementedException();
        }

        internal static void ViewProduct()
        {
            throw new NotImplementedException();
        }

        internal static List<Product> GetProducts()
        {
            using var db = new ProductsContext();

            var products = db.Products.ToList<Product>();

            return products;

        }
    }
}
