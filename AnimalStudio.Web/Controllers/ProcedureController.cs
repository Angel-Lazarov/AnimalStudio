using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Procedure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AnimalStudio.Web.Controllers
{
	[Authorize]
	public class ProcedureController : Controller
	{
		private readonly IProcedureService procedureService;
		private readonly IWorkerService workerService;

		public ProcedureController(IProcedureService procedureService, IWorkerService workerService)
		{
			this.procedureService = procedureService;
			this.workerService = workerService;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> ProcedureDetails(int id)
		{
			ProcedureDetailsViewModel? model = await procedureService.GetProcedureDetailsByIdAsync(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<ProcedureIndexViewModel> procedures = await procedureService.IndexGetAllProceduresAsync();

			return View(procedures);
		}

		[HttpGet]
		public IActionResult AddProcedure()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddProcedure(AddProcedureFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await procedureService.AddProcedureAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> DeleteProcedure(int id)
		{
			ProcedureDetailsViewModel? model = await procedureService.GetProcedureDetailsByIdAsync(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> DeleteProcedure(ProcedureDetailsViewModel model)
		{
			await procedureService.ProcedureDeleteAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> EditProcedure(int id)
		{
			EditProcedureFormModel? model = await procedureService.GetEditedModel(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditProcedure(EditProcedureFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await procedureService.EditProcedureAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> AssignToWorker(int id)
		{
			AssignProcedureToWorkerInputModel? viewModel = await procedureService
				.GetAssignProcedureToWorkerInputModelByIdAsync(id);

			if (viewModel == null)
			{
				return this.RedirectToAction(nameof(Index));
			}

			return this.View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> AssignToWorker(AssignProcedureToWorkerInputModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			bool result = await procedureService.AssignProcedureToWorkersAsync(model.Id, model);

			if (result == false)
			{
				return this.RedirectToAction(nameof(Index));
			}

			return this.RedirectToAction(nameof(Index), "Worker");
		}
	}
}
