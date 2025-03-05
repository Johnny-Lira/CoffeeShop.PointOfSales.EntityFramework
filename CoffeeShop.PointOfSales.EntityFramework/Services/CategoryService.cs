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

        internal static Category? GetCategoryOptionInput()
        {
            var categories = CategoryController.GetCategories();
            var categoriesArray = categories.Select(p => p.Name).ToList();
            categoriesArray.Add("Back");

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a category")
                    .AddChoices(categoriesArray)
            );

            if (option.Equals("Back"))
            {
                return null;
            }

            var id = categories.Single(x => x.Name == option).CategoryId;
            var category = CategoryController.GetCategoryById(id);

            return category;
        }

        internal static void DeleteCategory()
        {
            var category = GetCategoryOptionInput();

            if (category == null)
            {
                AnsiConsole.MarkupLine("[red]Category not found[/]");
                return;
            }

            var confirm = AnsiConsole.Confirm("Are you sure you want to delete this category?");
            
            if (!confirm)
                return;

            CategoryController.DeleteCategory(category);

        }
    }
}
