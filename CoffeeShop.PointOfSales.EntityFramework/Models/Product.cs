using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSales.EntityFramework.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required decimal Price { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}