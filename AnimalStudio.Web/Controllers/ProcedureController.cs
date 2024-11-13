using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels;
using AnimalStudio.Web.ViewModels.Procedure;
using Microsoft.AspNetCore.Mvc;


namespace AnimalStudio.Web.Controllers
{
	public class ProcedureController : Controller
	{
		private readonly IProcedureService procedureService;

		public ProcedureController(IProcedureService procedureService)
		{
			this.procedureService = procedureService;
		}

		[HttpGet]
		public async Task<IActionResult> ProcedureDetails(int id)
		{
			var model = await procedureService.GetProcedureDetailsByIdAsync(id);

			return View(model);
		}


		[HttpGet]
		public async Task<IActionResult> ProcedureList()
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

			return RedirectToAction("ProcedureList");
		}

		[HttpGet]
		public IActionResult DeleteProcedure()

		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> DeleteProcedureAsync(int id)
		{
			await procedureService.ProcedureDelete(id);
			return RedirectToAction(nameof(ProcedureList));
		}
	}
}
