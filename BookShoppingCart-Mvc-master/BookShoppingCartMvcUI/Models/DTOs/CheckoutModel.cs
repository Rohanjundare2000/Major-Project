using System.ComponentModel.DataAnnotations;

namespace BookShoppingCartMvcUI.Models.DTOs
{
    public class CheckoutModel
    {
        // Name of the person checking out, required field with a max length of 30 characters
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }

        // Email address of the person checking out, required field with email format validation and max length of 30 characters
        [Required]
        [EmailAddress]
        [MaxLength(30)]
        public string? Email { get; set; }

        // Mobile number of the person checking out, required field
        [Required]
        public string? MobileNumber { get; set; }

        // Shipping address for the order, required field with a max length of 200 characters
        [Required]
        [MaxLength(200)]
        public string? Address { get; set; }

        // Payment method chosen for the order, required field
        [Required]
        public string? PaymentMethod { get; set; }
    }
}
