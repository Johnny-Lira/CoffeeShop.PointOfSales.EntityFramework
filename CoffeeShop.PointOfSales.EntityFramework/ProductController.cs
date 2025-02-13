
using Spectre.Console;

namespace CoffeeShop.PointOfSales.EntityFramework
{
    public class ProductController
    {

        public static void AddProduct()
        {
            var name = AnsiConsole.Ask<string>("Enter the name of the product");
            using var db = new ProductsContext();
            db.Add(new Product { Name = name });
            db.SaveChanges();
        }

        public static void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public static Product? GetProductById( int id)
        {
            using var db = new ProductsContext();
            var product = db.Products.SingleOrDefault(p => p.Id == id);
            return product;
        }

        public static void UpdateProduct()
        {
            throw new NotImplementedException();
        }

        public static void ViewProduct()
        {
            throw new NotImplementedException();
        }

        public static List<Product> GetProducts()
        {
            using var db = new ProductsContext();

            var products = db.Products.ToList<Product>();

            return products;

        }
    }
}
