using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnimalStudio.Web.Controllers
{
	public class WorkerController : Controller
	{
		private readonly IWorkerService workerService;

		public WorkerController(IWorkerService workerService)
		{
			this.workerService = workerService;
		}

		public async Task<IActionResult> Index()
		{
			IEnumerable<WorkerViewModel> workersList = await workerService.GetAllWorkersAsync();

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

			await workerService.Worker_Add(model);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult DeleteWorker()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> DeleteWorker(int id)
		{
			await workerService.Worker_Delete(id);

			return RedirectToAction("Index");
		}
	}
}
