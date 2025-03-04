using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoffeeShop.PointOfSales.EntityFramework.Models;

namespace CoffeeShop.PointOfSales.EntityFramework
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; }
    }
}
