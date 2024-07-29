using Humanizer;
using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Numerics;

namespace BookShoppingCartMvcUI.Models
{
    // Map this class to the "Order" table in the database
    [Table("Order")]
    public class Order
    {
        // Primary key for the Order table
        public int Id { get; set; }

        // ID of the user who placed the order, required field
        [Required]
        public string UserId { get; set; }

        // Date and time when the order was created, defaults to current UTC time
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        // Status ID of the order, required field
        [Required]
        public int OrderStatusId { get; set; }

        // Flag to indicate if the order is marked as deleted, defaults to false
        public bool IsDeleted { get; set; } = false;

        // Name of the person who placed the order, required field, max length 30 characters
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }


         //   Email is a required field that stores the email address of the person who placed the 
        // order.It is also limited to a maximum length of 30 characters and must follow the email address format.
        // Email of the person who placed the order, required field, must be a valid email, max length 30 characters
        [Required]
        [EmailAddress]
        [MaxLength(30)]
        public string? Email { get; set; }

        // Mobile phone number of the person who placed the order, required field
        [Required]
        public string? MobileNumber { get; set; }

        // Shipping address for the order, required field, max length 200 characters
        [Required]
        [MaxLength(200)]
        public string? Address { get; set; }

        // Payment method used for the order, required field, max length 30 characters
        [Required]
        [MaxLength(30)]
        public string? PaymentMethod { get; set; }

        // Flag to indicate if the order has been paid
        public bool IsPaid { get; set; }

        // Navigation property to access the detailed information about the order's status
        public OrderStatus OrderStatus { get; set; }

        // Navigation property to access the details of each item in the order
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
