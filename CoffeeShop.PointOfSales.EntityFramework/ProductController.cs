using CoffeeShop.PointOfSales.EntityFramework.Models;
using Spectre.Console;

namespace CoffeeShop.PointOfSales.EntityFramework
{
    public class ProductController
    {

        public static void AddProduct(string name)
        {
            using var db = new ProductsContext();
            db.Add(new Product { Name = name });
            
            db.SaveChanges();
        }

        public static void DeleteProduct(Product product)
        {
            using var db = new ProductsContext();
            db.Remove(product);
            db.SaveChanges();
        }

        public static Product? GetProductById( int id)
        {
            using var db = new ProductsContext();
            var product = db.Products.SingleOrDefault(p => p.Id == id);
            return product;
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

        public static void UpdateProduct(Product product)
        {
            using var db = new ProductsContext();
            db.Update(product);
            db.SaveChanges();
        }
    }
}