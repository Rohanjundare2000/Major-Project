using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShoppingCartMvcUI.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        // Primary key for the OrderDetail table
        public int Id { get; set; }

        // Foreign key to the Order table, required field
        [Required]
        public int OrderId { get; set; }

        // Foreign key to the Book table, required field
        [Required]
        public int BookId { get; set; }

        // Quantity of the book ordered, required field
        [Required]
        public int Quantity { get; set; }

        // Unit price of the book ordered, required field
        [Required]
        public double UnitPrice { get; set; }

        // Navigation property to access the related Order entity
        public Order Order { get; set; }

        // Navigation property to access the related Book entity
        public Book Book { get; set; }
    }
}
