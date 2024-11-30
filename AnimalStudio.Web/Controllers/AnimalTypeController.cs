using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.AnimalType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalStudio.Web.Controllers
{
	[Authorize]
	public class AnimalTypeController : BaseController
	{
		private readonly IAnimalTypeService animalTypeService;

		public AnimalTypeController(IAnimalTypeService animalTypeService, IManagerService managerService)
			: base(managerService)
		{
			this.animalTypeService = animalTypeService;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<AnimalTypeViewModel> animalTypesList = await animalTypeService.IndexGetAllAnimalTypesAsync();

			return View(animalTypesList);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> AnimalTypeDetails(int id)
		{
			AnimalTypeViewModel model = await animalTypeService.GetAnimalTypeDetailsByIdAsync(id);

			return View(model);
		}

		[HttpGet]
		public IActionResult AddAnimalType()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddAnimalType(AnimalTypeViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await animalTypeService.AddAnimalTypeAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> DeleteAnimalType(int id)
		{
			await animalTypeService.GetAnimalTypeDetailsByIdAsync(id);

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> DeleteAnimalType(AnimalTypeViewModel model)
		{
			await animalTypeService.AnimalTypeDeleteAsync(model);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> EditAnimalType(int id)
		{
			AnimalTypeViewModel model = await animalTypeService.GetEditedModel(id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditAnimalType(AnimalTypeViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await animalTypeService.EditAnimalTypeAsync(model);

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

			IEnumerable<AnimalTypeViewModel> animalTypesList = await animalTypeService.IndexGetAllAnimalTypesAsync();

			return View(animalTypesList);
		}
	}
}
