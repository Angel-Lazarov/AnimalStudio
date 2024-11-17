using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Worker;
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
    }
}
