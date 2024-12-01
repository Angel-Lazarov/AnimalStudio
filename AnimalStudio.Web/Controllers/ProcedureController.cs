using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Procedure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AnimalStudio.Web.Controllers
{
	public class ProcedureController : BaseController
	{
		private readonly IProcedureService procedureService;

		public ProcedureController(IProcedureService procedureService, IManagerService managerService)
		: base(managerService)
		{
			this.procedureService = procedureService;
		}

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

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<ProcedureIndexViewModel> procedures = await procedureService.IndexGetAllProceduresAsync();

			return View(procedures);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> AddProcedure()
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return this.RedirectToAction(nameof(Index));
			}

			return View();
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> AddProcedure(AddProcedureFormModel model)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return this.RedirectToAction(nameof(Index));
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await procedureService.AddProcedureAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> DeleteProcedure(int id)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return this.RedirectToAction(nameof(Index));
			}

			DeleteProcedureViewModel? procedureToDeleteViewModel = await procedureService.GetProcedureForDeleteByIdAsync(id);

			if (procedureToDeleteViewModel == null)
			{
				return RedirectToAction(nameof(Manage));
			}
			return View(procedureToDeleteViewModel);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> SoftDeleteConfirmed(DeleteProcedureViewModel model)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return this.RedirectToAction(nameof(Index));
			}

			bool isDeleted = await procedureService
				.SoftDeleteProcedureAsync(model.Id);

			if (!isDeleted)
			{
				TempData["ErrorMessage"] =
					"The procedure is deleted or the procedure is in use. ";
				return this.RedirectToAction(nameof(DeleteProcedure), new { id = model.Id });
			}
			return this.RedirectToAction(nameof(Manage));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> EditProcedure(int id)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return this.RedirectToAction(nameof(Index));
			}

			EditProcedureFormModel? model = await procedureService.GetEditedModel(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> EditProcedure(EditProcedureFormModel model)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return this.RedirectToAction(nameof(Index));
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			bool isUpdated = await procedureService.EditProcedureAsync(model);

			if (!isUpdated)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating the cinema! Please contact administrator");
				return this.View(model);
			}

			return RedirectToAction(nameof(Index), "Procedure", new { id = model.Id });
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


		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Manage()
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			IEnumerable<ProcedureIndexViewModel> procedures = await procedureService.IndexGetAllProceduresAsync();

			return View(procedures);
		}

	}
}
