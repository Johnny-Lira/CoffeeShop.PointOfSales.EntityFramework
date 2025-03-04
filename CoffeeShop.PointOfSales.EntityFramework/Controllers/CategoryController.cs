using CoffeeShop.PointOfSales.EntityFramework.Models;

namespace CoffeeShop.PointOfSales.EntityFramework.Controllers
{
    internal class CategoryController
    {
        internal static void AddCategory(Category category)
        {
            using var db = new ProductsContext();

            db.Categories.Add(category);
            db.SaveChanges();
        }

        public static Category? GetCategoryById(int id)
        {
            using var db = new ProductsContext();
            var category = db.Categories.SingleOrDefault(p => p.CategoryId == id);
            return category;
        }


        internal static List<Category> GetCategories()
        {
            using var db = new ProductsContext();

            return db.Categories.ToList();
        }


    }
}
