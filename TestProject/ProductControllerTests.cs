using Xunit;
using Moq;
using CoffeeShop.PointOfSales.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestProject
{
    public class ProductControllerTests
    {
        [Fact]
        public void AddProduct_ShouldAddProductToDatabase()
        {
            // Arrange
            var mockContext = new Mock<ProductsContext>();
            var mockSet = new Mock<DbSet<Product>>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            // Act
            ProductController.AddProduct();

            // Assert
            mockSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void GetProductById_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var mockContext = new Mock<ProductsContext>();
            var mockSet = new Mock<DbSet<Product>>();
            var product = new Product { Id = 1, Name = "Test Product" };
            mockSet.Setup(m => m.Find(1)).Returns(product);
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            // Act
            var result = ProductController.GetProductById(1);

            // Assert
            Assert.Equal(product, result);
        }

        [Fact]
        public void GetProducts_ShouldReturnAllProducts()
        {
            // Arrange
            var mockContext = new Mock<ProductsContext>();
            var mockSet = new Mock<DbSet<Product>>();
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1" },
            new Product { Id = 2, Name = "Product 2" }
        }.AsQueryable();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            // Act
            var result = ProductController.GetProducts();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Product 1", result[0].Name);
            Assert.Equal("Product 2", result[1].Name);
        }
    }
}






