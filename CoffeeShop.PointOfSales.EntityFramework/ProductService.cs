﻿using CoffeeShop.PointOfSales.EntityFramework.Models;
using Spectre.Console;

namespace CoffeeShop.PointOfSales.EntityFramework
{
    internal class ProductService
    {
        internal static void InsertProduct()
        {
            ProductController.AddProduct(AnsiConsole.Ask<string>("Enter the name of the product"));

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
                product.Name = AnsiConsole.Ask<string>("Enter the new name of the product");
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

            var id = products.Single(x => x.Name == option).Id;
            var product = ProductController.GetProductById(id);

            return product;
        }
    }
}
