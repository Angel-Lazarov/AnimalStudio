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
		public async Task<IActionResult> ProcedureList()
		{
			IEnumerable<ProcedureViewModel> procedures = await procedureDataService.GetAllProceduresAsync();

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
		public async Task<IActionResult> DeleteProcedureAsync(int id)
		{
			await procedureDataService.Procedure_Delete(id);
			return View();
		}


	}
}
