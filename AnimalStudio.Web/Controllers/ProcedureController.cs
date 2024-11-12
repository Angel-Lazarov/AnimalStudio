using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels;
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
		public async Task<IActionResult> ProcedureList()
		{
			IEnumerable<ProcedureViewModel> procedures = await procedureService.GetAllProceduresAsync();

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

			await procedureService.Procedure_Add(model);

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
			await procedureService.Procedure_Delete(id);
			return RedirectToAction(nameof(ProcedureList));
		}
	}
}
