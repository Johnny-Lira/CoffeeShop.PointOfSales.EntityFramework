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

        internal static List<Category> GetCategories()
        {
            using var db = new ProductsContext();

            return db.Categories.ToList();
        }
    }
}
