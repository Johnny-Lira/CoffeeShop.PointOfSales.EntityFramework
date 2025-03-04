using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.PointOfSales.EntityFramework.Controllers;
using Spectre.Console;

namespace CoffeeShop.PointOfSales.EntityFramework.Services
{
    internal class CategoryService
    {
        internal static void InsertCategory()
        {
            var category = new Category()
            {
                Name = AnsiConsole.Ask<string>("Enter the name of the category: ")
            };

            CategoryController.AddCategory(category);
        }

        internal static void GetCategories()
        {
            var categories = CategoryController.GetCategories();
            UserInterface.ShowCategoryTable(categories);
        }
    }
}
