using BookShoppingCartMvcUI.Constants; // Importing namespace for constants
using Microsoft.AspNetCore.Authorization; // Provides authorization functionality
using Microsoft.AspNetCore.Mvc; // Provides functionalities for MVC pattern
using Microsoft.AspNetCore.Mvc.Rendering; // Provides functionality for creating HTML elements

namespace BookShoppingCartMvcUI.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))] // Ensures only users with the 'Admin' role can access this controller
    public class AdminOperationsController : Controller
    {
        private readonly IUserOrderRepository _userOrderRepository; // Repository for user orders

        public AdminOperationsController(IUserOrderRepository userOrderRepository)
        {
            _userOrderRepository = userOrderRepository; // Dependency injection for user order repository
        }


        public async Task<IActionResult> AllOrders()
        {
            var orders = await _userOrderRepository.UserOrders(true); // Retrieves all user orders asynchronously
            return View(orders); // Passes the list of orders to the view
        }



        public async Task<IActionResult> TogglePaymentStatus(int orderId)
        {
            try
            {
                await _userOrderRepository.TogglePaymentStatus(orderId); // Toggles the payment status of the order asynchronously
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction(nameof(AllOrders)); // Redirects to the AllOrders action
        }




        public async Task<IActionResult> UpdateOrderStatus(int orderId)
        {
            var order = await _userOrderRepository.GetOrderById(orderId); // Retrieves the order by id asynchronously
            if (order == null)
            {
                throw new InvalidOperationException($"Order with id:{orderId} does not found."); // Throws an exception if order not found
            }
            var orderStatusList = (await _userOrderRepository.GetOrderStatuses()).Select(orderStatus =>
            {
                return new SelectListItem
                {
                    Value = orderStatus.Id.ToString(),
                    Text = orderStatus.StatusName,
                    Selected = order.OrderStatusId == orderStatus.Id
                };
            }); // Creates a list of SelectListItems for the order statuses




            var data = new UpdateOrderStatusModel
            {
                OrderId = orderId,
                OrderStatusId = order.OrderStatusId,
                OrderStatusList = orderStatusList
            }; // Creates an UpdateOrderStatusModel with the order data and status list
            return View(data); // Passes the model to the view
        }





         
        [HttpPost] // Specifies this action handles POST requests
        public async Task<IActionResult> UpdateOrderStatus(UpdateOrderStatusModel data)
        {
            try
            {
                if (!ModelState.IsValid) // Checks if the model state is valid
                {
                    data.OrderStatusList = (await _userOrderRepository.GetOrderStatuses()).Select(orderStatus =>
                    {
                        return new SelectListItem
                        {
                            Value = orderStatus.Id.ToString(),
                            Text = orderStatus.StatusName,
                            Selected = orderStatus.Id == data.OrderStatusId
                        };
                    }); // Updates the status list in the model

                    return View(data); // Returns the same view with the current model if invalid
                }
                await _userOrderRepository.ChangeOrderStatus(data); // Changes the order status asynchronously
                TempData["msg"] = "Updated successfully"; // Sets a success message
            }
            catch (Exception ex)
            {
                // catch exception here
                TempData["msg"] = "Something went wrong"; // Sets an error message
            }
            return RedirectToAction(nameof(UpdateOrderStatus), new { orderId = data.OrderId }); // Redirects to the UpdateOrderStatus action
        }

        public IActionResult Dashboard()
        {
            return View(); // Returns the view for the admin dashboard
        }
    }
}
