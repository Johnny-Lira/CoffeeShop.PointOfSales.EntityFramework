using CoffeeShop.PointOfSales.EntityFramework;
using CoffeeShop.PointOfSales.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestProject
{
    public class ProductControllerTests
    {
        private readonly DbContextOptions<ProductsContext> _options;

        public ProductControllerTests()
        {
            _options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

    //    [Fact]
    //    public void AddProduct_ShouldAddProductToDatabase()
    //    {
    //        // Arrange
    //        var product = new Product { Name = "Test Product", Price = 10.99m };
    //        using (var context = new ProductsContext(_options))
    //        {
    //            var controller = new ProductController(context);

    //            // Act
    //            controller.AddProduct(product);

    //            // Assert
    //            var result = context.Products.FirstOrDefault(p => p.Name == "Test Product");
    //            Assert.NotNull(result);
    //            Assert.Equal(product.Name, result.Name);
    //            Assert.Equal(product.Price, result.Price);
    //        }
    //    }

    //    [Fact]
    //    public void GetProductById_ShouldReturnProduct_WhenProductExists()
    //    {
    //        // Arrange
    //        var product = new Product { Id = 1, Name = "Test Product" };
    //        using (var context = new ProductsContext(_options))
    //        {
    //            context.Products.Add(product);
    //            context.SaveChanges();
    //            var controller = new ProductController(context);

    //            // Act
    //            var result = controller.GetProductById(1);

    //            // Assert
    //            Assert.NotNull(result);
    //            Assert.Equal(product.Name, result.Name);
    //        }
    //    }

    //    [Fact]
    //    public void GetProducts_ShouldReturnAllProducts()
    //    {
    //        // Arrange
    //        var products = new List<Product>
    //            {
    //                new Product { Id = 1, Name = "Product 1" },
    //                new Product { Id = 2, Name = "Product 2" }
    //            };
    //        using (var context = new ProductsContext(_options))
    //        {
    //            context.Products.AddRange(products);
    //            context.SaveChanges();
    //            var controller = new ProductController(context);

    //            // Act
    //            var result = controller.GetProducts();

    //            // Assert
    //            Assert.Equal(2, result.Count);
    //            Assert.Equal("Product 1", result[0].Name);
    //            Assert.Equal("Product 2", result[1].Name);
    //        }
    //    }
    }
}






