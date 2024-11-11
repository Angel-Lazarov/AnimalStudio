using AnimalStudio.Services.Interfaces;
using AnimalStudio.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnimalStudio.Web.Controllers
{
	public class WorkerController : Controller
	{
		private readonly IWorkerDataService workerDataService;

		public WorkerController(IWorkerDataService workerDataService)
		{
			this.workerDataService = workerDataService;
		}
		public IActionResult WorkersList()
		{
			List<WorkerViewModel> workersList = workerDataService.Workers_All();
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

			bool addSuccess = await workerDataService.Worker_Add(model);

			return RedirectToAction("WorkersList");
		}


		[HttpGet]
		public IActionResult RemoveWorker()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> RemoveWorker(WorkerViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			bool removeSuccess = await workerDataService.Worker_Remove(model);

			return RedirectToAction("WorkersList");
		}


	}
}
