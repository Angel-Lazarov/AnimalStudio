using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static AnimalStudio.Common.ErrorMessages.Order;

namespace AnimalStudio.Web.Controllers
{
	[Authorize]
	public class OrderController : BaseController
	{
		private readonly IOrderService orderService;
		private readonly IProcedureService procedureService;
		private readonly IAnimalService animalService;

		public OrderController(IOrderService orderService, IProcedureService procedureService, IAnimalService animalService, IManagerService managerService)
			: base(managerService)
		{
			this.orderService = orderService;
			this.procedureService = procedureService;
			this.animalService = animalService;
		}

		[HttpGet]
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
				Animals = animals,
				UserId = userId,
				Owner = GetCurrentUserName()!
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddOrder(AddOrderFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Animals = await animalService.GetAllAnimalsByUserId(model.UserId);
				model.Procedures = await procedureService.IndexGetAllProceduresAsync();

				return View(model);
			}

			await orderService.AddOrderAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> MakeOrder(int id)
		{
			string userId = GetCurrentUserId()!;

			var animals = await animalService.GetAllAnimalsByUserId(userId);

			MakeOrderViewModel order = new MakeOrderViewModel()
			{
				ProcedureId = id,
				Animals = animals,
				UserId = userId
			};

			return View(order);
		}

		[HttpPost]
		public async Task<IActionResult> MakeOrder(MakeOrderViewModel order)
		{
			bool result = await orderService.AddMyOrderAsync(order);

			if (result == false)
			{
				TempData[nameof(DuplicatedOrder)] = DuplicatedOrder;
				return RedirectToAction("Index", "Procedure");
			}

			return RedirectToAction(nameof(Index));
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> RemoveOrder(Guid id)
		{
			bool result = await orderService.RemoveOrderAsync(id);

			if (result == false)
			{
				return BadRequest();
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Manage()
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			IEnumerable<OrderIndexViewModel> orders = await orderService.IndexGetAllOrdersAsync();

			return View(orders);
		}

		private string? GetCurrentUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}

		private string? GetCurrentUserName()
		{
			return User.Identity!.Name;
		}
	}
}
