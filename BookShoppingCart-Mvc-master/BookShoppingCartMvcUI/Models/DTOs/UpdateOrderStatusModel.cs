using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookShoppingCartMvcUI.Models.DTOs
{
    public class UpdateOrderStatusModel
    {
        // ID of the order whose status is being updated
        public int OrderId { get; set; }

        // ID of the new order status, required field
        [Required]
        public int OrderStatusId { get; set; }

        // A list of possible order statuses to select from
        public IEnumerable<SelectListItem>? OrderStatusList { get; set; }
    }
}
