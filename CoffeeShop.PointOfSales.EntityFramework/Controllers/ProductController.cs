﻿using CoffeeShop.PointOfSales.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace CoffeeShop.PointOfSales.EntityFramework.Controllers
{
    internal class ProductController
    {

        public static void AddProduct(Product product)
        {
            using var db = new ProductsContext();
            db.Add(product);

            db.SaveChanges();
        }

        public static void DeleteProduct(Product product)
        {
            using var db = new ProductsContext();
            db.Remove(product);
            db.SaveChanges();
        }

        public static Product? GetProductById(int id)
        {
            using var db = new ProductsContext();
            var product = db.Products
                .Include(x => x.Category)
                .SingleOrDefault(p => p.ProductId == id);
            return product;
        }

        public static void ViewProduct()
        {
            throw new NotImplementedException();
        }

        public static List<Product> GetProducts()
        {
            using var db = new ProductsContext();

            var products = db.Products
                .Include(x => x.Category)
                .ToList();

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