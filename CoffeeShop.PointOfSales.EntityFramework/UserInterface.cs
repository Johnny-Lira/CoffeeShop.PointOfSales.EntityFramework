﻿using CoffeeShop.PointOfSales.EntityFramework.Models;
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
                        .AddChoices(MenuOptions.AddProduct,
                        MenuOptions.DeleteProduct,
                        MenuOptions.UpdateProduct,
                        MenuOptions.ViewProduct,
                        MenuOptions.ViewAllProducts,
                        MenuOptions.Quit)
                );

                switch (option)
                {
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
            var panel = new Panel($@"Id: {product.Id} Name: {product.Name}");
            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);

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
                table.AddRow(product.Id.ToString(), product.Name, product.Price.ToString());
            }
            AnsiConsole.Write(table);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
