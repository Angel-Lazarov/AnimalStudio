using AnimalStudio.Services.Interfaces;
using AnimalStudio.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace AnimalStudio.Web.Controllers
{
	public class ProcedureController : Controller
	{
		private readonly IProcedureDataService procedureDataService;

		public ProcedureController(IProcedureDataService procedureDataService)
		{
			this.procedureDataService = procedureDataService;
		}

		[HttpGet]
		public IActionResult ProcedureList()
		{
			List<ProcedureViewModel> procedures = procedureDataService.GetAllProcedures();

			return View(procedures);
		}

		[HttpGet]
		public IActionResult AddProcedure()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddProcedure(ProcedureViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			await procedureDataService.Procedure_Add(model);
			return RedirectToAction("ProcedureList");
		}

		[HttpGet]
		public IActionResult DeleteProcedure()

		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> DeleteProcedureAsync(string modeleName)
		{
			await procedureDataService.Procedure_Delete(modeleName);
			return View();
		}


	}
}
