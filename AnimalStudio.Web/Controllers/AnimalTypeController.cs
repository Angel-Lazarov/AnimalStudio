using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.AnimalType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalStudio.Web.Controllers
{
	public class AnimalTypeController : BaseController
	{
		private readonly IAnimalTypeService animalTypeService;

		public AnimalTypeController(IAnimalTypeService animalTypeService, IManagerService managerService)
			: base(managerService)
		{
			this.animalTypeService = animalTypeService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<AnimalTypeViewModel> animalTypesList = await animalTypeService.IndexGetAllAnimalTypesAsync();

			return View(animalTypesList);
		}


		[HttpGet]
		public async Task<IActionResult> AnimalTypeDetails(int id)
		{
			AnimalTypeViewModel model = await animalTypeService.GetAnimalTypeDetailsByIdAsync(id);

			return View(model);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> AddAnimalType()
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			return View();
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> AddAnimalType(AnimalTypeViewModel model)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await animalTypeService.AddAnimalTypeAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> DeleteAnimalType(int id)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			DeleteAnimalTypeViewModel? animalTypeToDeleteViewModel = await animalTypeService.GetAnimalTypeForDeleteByIdAsync(id);

			if (animalTypeToDeleteViewModel == null)
			{
				return RedirectToAction(nameof(Manage));
			}

			return View(animalTypeToDeleteViewModel);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> DeleteConfirmed(DeleteAnimalTypeViewModel model)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return this.RedirectToAction(nameof(Index));
			}

			bool isInUse = await animalTypeService
				.DeleteAnimalTypeAsync(model.Id);

			if (!isInUse)
			{
				TempData["ErrorMessage"] =
					"The animal type is deleted or the animal type is in use. ";
				return this.RedirectToAction(nameof(DeleteAnimalType), new { id = model.Id });
			}

			return this.RedirectToAction(nameof(Manage));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> EditAnimalType(int id)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			AnimalTypeViewModel model = await animalTypeService.GetEditedModel(id);

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> EditAnimalType(AnimalTypeViewModel model)
		{
			bool isManager = await this.IsUserManagerAsync();
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

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
