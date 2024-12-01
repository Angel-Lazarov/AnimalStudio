using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Worker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AnimalStudio.Common.ErrorMessages.Worker;

namespace AnimalStudio.Web.Controllers
{
	public class WorkerController : BaseController
	{
		private readonly IWorkerService workerService;

		public WorkerController(IWorkerService workerService, IManagerService managerService)
			: base(managerService)
		{
			this.workerService = workerService;
		}

		[HttpGet]
		public async Task<IActionResult> WorkerDetails(int id)
		{
			WorkerDetailsViewModel? model = await workerService.GetWorkerDetailsByIdAsync(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<WorkerViewModel> workersList = await workerService.IndexGetAllWorkersAsync();

			return View(workersList);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> AddWorker()
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
		public async Task<IActionResult> AddWorker(WorkerViewModel model)
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

			bool result = await workerService.AddWorkerAsync(model);

			if (result == false)
			{
				TempData[nameof(DuplicatedWorker)] = DuplicatedWorker;
				return RedirectToAction("Index", "Worker");
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> DeleteWorker(int id)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			DeleteWorkerViewModel? workerToDeleteViewModel = await workerService.GetWorkerForDeleteByIdAsync(id);

			if (workerToDeleteViewModel == null)
			{
				return RedirectToAction(nameof(Manage));
			}

			return View(workerToDeleteViewModel);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> SoftDeleteConfirmed(DeleteWorkerViewModel model)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return this.RedirectToAction(nameof(Index));
			}

			bool isInUse = await workerService
				.SoftDeleteWorkerAsync(model.Id);

			if (!isInUse)
			{
				TempData[nameof(DeleteWorkerError)] = DeleteWorkerError;
				return this.RedirectToAction(nameof(DeleteWorker), new { id = model.Id });
			}

			return this.RedirectToAction(nameof(Manage));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> EditWorker(int id)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return this.RedirectToAction(nameof(Index));
			}

			WorkerViewModel? model = await workerService.GetEditedModel(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> EditWorker(WorkerViewModel model)
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

			await workerService.EditWorkerAsync(model);

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

			IEnumerable<WorkerViewModel> workersList = await workerService.IndexGetAllWorkersAsync();

			return View(workersList);
		}
	}
}