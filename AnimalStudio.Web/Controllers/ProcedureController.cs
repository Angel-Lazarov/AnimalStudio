using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Procedure;
using Microsoft.AspNetCore.Mvc;


namespace AnimalStudio.Web.Controllers
{
	public class ProcedureController : Controller
	{
		private readonly IProcedureService procedureService;
		private readonly IWorkerService workerService;

		public ProcedureController(IProcedureService procedureService, IWorkerService workerService)
		{
			this.procedureService = procedureService;
			this.workerService = workerService;
		}

		[HttpGet]
		public async Task<IActionResult> ProcedureDetails(int id)
		{
			var model = await procedureService.GetProcedureDetailsByIdAsync(id);

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<ProcedureIndexViewModel> procedures = await procedureService.IndexGetAllProceduresAsync();

			return View(procedures);
		}

		[HttpGet]
		public async Task<IActionResult> AddProcedure()
		{
            AddProcedureFormModel model = new AddProcedureFormModel();
			model.Workers = await workerService.GetAllWorkersAsync();
            return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddProcedure(AddProcedureFormModel model)
		{
			if (!ModelState.IsValid)
			{
                model.Workers = await workerService.GetAllWorkersAsync();
                return View(model);
			}

			await procedureService.AddProcedureAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> DeleteProcedure(int id)
		{
			var model = await procedureService.GetProcedureDetailsByIdAsync(id);

            await procedureService.ProcedureDelete(model);
            return RedirectToAction(nameof(Index));

        }

  //      [HttpPost]
		//public async Task<IActionResult> DeleteProcedure(ProcedureDetailsViewModel model)
		//{
		//	await procedureService.ProcedureDelete(model);
		//	return RedirectToAction(nameof(Index));
		//}
	}
}
