using System.ComponentModel.DataAnnotations; // Provides attributes for data validation
using System.ComponentModel.DataAnnotations.Schema; // Provides attributes for mapping classes to database tables

//Admin: login => Books => navbar

namespace BookShoppingCartMvcUI.Models
{
    [Table("Book")] // Maps this class to the "Book" table in the database
    public class Book
    {
        public int Id { get; set; } // Primary key for the "Book" table

        [Required] // Specifies that this property is required (non-nullable)
        [MaxLength(40)] // Specifies the maximum length of 40 characters for this property
        public string? BookName { get; set; } // Name of the book, optional (nullable)

        [Required] // Specifies that this property is required (non-nullable)
        [MaxLength(40)] // Specifies the maximum length of 40 characters for this property
        public string? AuthorName { get; set; } // Name of the author, optional (nullable)

        [Required] // Specifies that this property is required (non-nullable)
        public double Price { get; set; } // Price of the book

        public string? Image { get; set; } // URL or path to the book's image, optional (nullable)

        [Required] // Specifies that this property is required (non-nullable)
        public int GenreId { get; set; } // Foreign key referencing the Genre entity

    
        
  
        
        
        public Genre Genre { get; set; } // Navigation property for the Genre entity

        public List<OrderDetail> OrderDetail { get; set; } // Navigation property for related OrderDetail entities

        public List<CartDetail> CartDetail { get; set; } // Navigation property for related CartDetail entities

        public Stock Stock { get; set; } // Navigation property for the Stock entity

        [NotMapped] // Specifies that this property is not mapped to any column in the database
        public string GenreName { get; set; } // Genre name, used for display purposes

        [NotMapped] // Specifies that this property is not mapped to any column in the database
        public int Quantity { get; set; } // Quantity, used for display purposes or calculations
    }
}
