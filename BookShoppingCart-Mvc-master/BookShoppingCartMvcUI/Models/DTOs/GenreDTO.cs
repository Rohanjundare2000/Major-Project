
using System.ComponentModel.DataAnnotations;
// admin =>navbar=> genre 
namespace BookShoppingCartMvcUI.Models.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string GenreName { get; set; }
    }
}
