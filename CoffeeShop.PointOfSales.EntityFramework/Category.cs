using System.ComponentModel.DataAnnotations;
using CoffeeShop.PointOfSales.EntityFramework.Models;

namespace CoffeeShop.PointOfSales.EntityFramework
{
    internal class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; }
    }
}
