using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Worker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalStudio.Web.Controllers
{
	[Authorize]
	public class WorkerController : BaseController
	{
		private readonly IWorkerService workerService;

		public WorkerController(IWorkerService workerService, IManagerService managerService)
			: base(managerService)
		{
			this.workerService = workerService;
		}

		[AllowAnonymous]
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

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<WorkerViewModel> workersList = await workerService.IndexGetAllWorkersAsync();

			return View(workersList);
		}

		[HttpGet]
		public IActionResult AddWorker()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddWorker(WorkerViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await workerService.AddWorkerAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> DeleteWorker(int id)
		{
			WorkerDetailsViewModel? model = await workerService.GetWorkerDetailsByIdAsync(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> DeleteWorker(WorkerViewModel model)
		{
			await workerService.WorkerDeleteAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> EditWorker(int id)
		{
			WorkerViewModel? model = await workerService.GetEditedModel(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditWorker(WorkerViewModel model)
		{
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