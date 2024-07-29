using System.ComponentModel.DataAnnotations;

namespace BookShoppingCartMvcUI.Models.DTOs
{
    public class StockDTO
    {
        // ID of the book whose stock is being managed
        public int BookId { get; set; }

        // Quantity of the book in stock, must be a non-negative value
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
        public int Quantity { get; set; }
    }
}
