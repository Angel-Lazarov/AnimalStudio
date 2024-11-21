using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimalStudio.Web.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService orderService;
		private readonly IProcedureService procedureService;
		private readonly IAnimalService animalService;

		public OrderController(IOrderService orderService, IProcedureService procedureService, IAnimalService animalService)
		{
			this.orderService = orderService;
			this.procedureService = procedureService;
			this.animalService = animalService;
		}

		public async Task<IActionResult> Index()
		{
			string userId = GetCurrentUserId()!;

			IEnumerable<OrderIndexViewModel> orders = await orderService.IndexGetMyOrdersAsync(userId);

			return View(orders);
		}

		[HttpGet]
		public async Task<IActionResult> AddOrder()
		{
			string userId = GetCurrentUserId()!;
			var animals = await animalService.GetAllAnimalsByUserId(userId);
			var procedures = await procedureService.IndexGetAllProceduresAsync();

			AddOrderFormViewModel model = new AddOrderFormViewModel()
			{
				Procedures = procedures,
				Animals = animals
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddOrder(AddOrderFormViewModel model)
		{
			string userId = GetCurrentUserId()!;

			if (!ModelState.IsValid)
			{
				model.Animals = await animalService.GetAllAnimalsByUserId(userId);
				model.Procedures = await procedureService.IndexGetAllProceduresAsync();

				return View(model);
			}

			await orderService.AddOrderAsync(userId, model);

			return RedirectToAction(nameof(Index));
		}




		[HttpGet]
		public async Task<IActionResult> MakeOrder(int procedureId)
		{
			string userId = GetCurrentUserId()!;

			var animals = await animalService.GetAllAnimalsByUserId(userId);

			AddOrderFormViewModel order = new AddOrderFormViewModel()
			{
				ProcedureId = procedureId,
				Animals = animals
			};

			return View(order);
		}

		[HttpPost]
		public async Task<IActionResult> MakeOrder(AddOrderFormViewModel order)
		{
			string userId = GetCurrentUserId()!;

			await orderService.AddOrderAsync(userId, order);

			return RedirectToAction(nameof(Index));
		}




		private string? GetCurrentUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
