using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookShoppingCartMvcUI.Models
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string GenreName { get; set; }
        public List<Book> Books { get; set; }
        // one to many
        //The Genre class has a one-to-many relationship with the
        //Book class, as indicated by the Books property.
    }
}
