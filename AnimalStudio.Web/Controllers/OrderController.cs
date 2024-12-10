using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using static AnimalStudio.Common.EntityValidationConstants.Order;
using static AnimalStudio.Common.EntityValidationMessages.Order;
using static AnimalStudio.Common.ErrorMessages.Order;


namespace AnimalStudio.Web.Controllers
{
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
        [Authorize]
        public async Task<IActionResult> Index(OrderSearchFilterViewModel inputModel)
        {
            string userId = GetCurrentUserId()!;
            IEnumerable<OrderIndexViewModel> orders = await orderService.IndexGetMyOrdersAsync(userId, inputModel);

            OrderSearchFilterViewModel viewModel = new OrderSearchFilterViewModel();
            viewModel.AllProcedures = await orderService.GetAllProceduresAsync();
            viewModel.Orders = orders;

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
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

            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddOrder(AddOrderFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Animals = await animalService.GetAllAnimalsByUserId(model.UserId);
                model.Procedures = await procedureService.IndexGetAllProceduresAsync();

                return View(model);
            }

            bool isCreatedOnDateValid = DateTime.TryParseExact(model.ReservationDate, ReservationDateFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime createdOn);

            if (!isCreatedOnDateValid)
            {
                ModelState.AddModelError(nameof(model.ReservationDate), CreatedOnRequiredMessage);
                model.Animals = await animalService.GetAllAnimalsByUserId(model.UserId);
                model.Procedures = await procedureService.IndexGetAllProceduresAsync();
                return View(model);
            }

            if (createdOn < DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.ReservationDate), CreatedOnBeforeMessage);
                model.Animals = await animalService.GetAllAnimalsByUserId(model.UserId);
                model.Procedures = await procedureService.IndexGetAllProceduresAsync();
                return View(model);
            }

            bool result = await orderService.AddOrderAsync(model);

            if (result == false)
            {
                TempData[nameof(DuplicatedOrder)] = DuplicatedOrder;
                return RedirectToAction("Index", "Procedure");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> BuyOrder(int id)
        {
            string userId = GetCurrentUserId()!;
            var animals = await animalService.GetAllAnimalsByUserId(userId);

            AddOrderFormViewModel order = new AddOrderFormViewModel()
            {
                ProcedureId = id,
                Animals = animals,
                UserId = userId
            };

            return View(order);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> BuyOrder(AddOrderFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            bool isCreatedOnDateValid = DateTime.TryParseExact(model.ReservationDate, ReservationDateFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime createdOn);

            if (!isCreatedOnDateValid)
            {
                ModelState.AddModelError(nameof(model.ReservationDate), CreatedOnRequiredMessage);
                model.Animals = await animalService.GetAllAnimalsByUserId(model.UserId);
                return View(model);
            }

            if (createdOn < DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.ReservationDate), CreatedOnBeforeMessage);
                model.Animals = await animalService.GetAllAnimalsByUserId(model.UserId);
                return View(model);
            }

            bool result = await orderService.AddOrderAsync(model);

            if (result == false)
            {
                TempData[nameof(DuplicatedOrder)] = DuplicatedOrder;
                return RedirectToAction("Index", "Procedure");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteOrder(string? id)
        {
            Guid orderGuid = Guid.Empty;
            if (!this.IsGuidValid(id, ref orderGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            DeleteOrderViewModel? orderToDeleteViewModel = await orderService.GetOrderForDeleteByIdAsync(orderGuid);

            if (orderToDeleteViewModel == null)
            {
                return RedirectToAction(nameof(Manage));
            }

            return View(orderToDeleteViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SoftDeleteConfirmed(DeleteOrderViewModel model)
        {
            Guid orderGuid = Guid.Empty;
            if (!this.IsGuidValid(model.Id, ref orderGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            bool isDeleted = await orderService
                .SoftDeleteOrderAsync(orderGuid);

            if (!isDeleted)
            {
                TempData[nameof(DeleteOrderError)] = DeleteOrderError;
                return this.RedirectToAction(nameof(DeleteOrder), new { id = model.Id });
            }
            return this.RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Manage(OrderSearchFilterViewModel inputModel)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return RedirectToAction(nameof(Index));
            }

            IEnumerable<OrderIndexViewModel> orders = await orderService.IndexGetAllOrdersAsync(inputModel);

            OrderSearchFilterViewModel viewModel = new OrderSearchFilterViewModel();
            viewModel.AllProcedures = await orderService.GetAllProceduresAsync();
            viewModel.AllAnimalTypes = await orderService.GetAllAnimalTypesAsync();
            viewModel.Orders = orders;

            return View(viewModel);
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
