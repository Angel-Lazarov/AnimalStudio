using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimalStudio.Web.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService orderService;

		public OrderController(IOrderService orderService)
		{
			this.orderService = orderService;
		}

		public async Task<IActionResult> Index()
		{
			string userId = GetCurrentUserId()!;

			IEnumerable<OrderIndexViewModel> orders = await orderService.IndexGetMyOrdersAsync(userId);

			return View(orders);
		}


		private string? GetCurrentUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
