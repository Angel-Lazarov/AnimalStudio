using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Animal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static AnimalStudio.Common.ErrorMessages.Animal;

namespace AnimalStudio.Web.Controllers
{
	public class AnimalController : BaseController
	{
		private readonly IAnimalService animalService;
		private readonly IAnimalTypeService animalTypeService;

		public AnimalController(IAnimalService animalService, IAnimalTypeService animalTypeService, IManagerService managerService)
		: base(managerService)
		{
			this.animalService = animalService;
			this.animalTypeService = animalTypeService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<AnimalIndexViewModel> animals = await animalService.IndexGetAllAnimalsAsync();

			return View(animals);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> MyIndex()
		{
			string currentUserId = GetCurrentUserId()!;

			IEnumerable<AnimalDetailsViewModel> animals = await animalService.IndexGetMyAnimalsAsync(currentUserId);

			return View(animals);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> AddAnimal()
		{
			string currentUserId = GetCurrentUserId()!;

			AddAnimalFormModel model = new AddAnimalFormModel()
			{
				AnimalTypes = await animalTypeService.IndexGetAllAnimalTypesAsync(),
				UserId = currentUserId
			};

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> AddAnimal(AddAnimalFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model.AnimalTypes = await animalTypeService.IndexGetAllAnimalTypesAsync();

				return View(model);
			}

			bool result = await animalService.AddAnimalAsync(model);

			if (result == false)
			{
				TempData[nameof(DuplicatedAnimal)] = DuplicatedAnimal;
				return RedirectToAction("MyIndex", "Animal");
			}

			return RedirectToAction(nameof(MyIndex));
		}

		[HttpGet]
		public async Task<IActionResult> AnimalDetails(string? id)
		{
			Guid animalGuid = Guid.Empty;
			bool isIdValid = IsGuidValid(id, ref animalGuid);
			if (!isIdValid)
			{
				return RedirectToAction(nameof(MyIndex));
			}


			AnimalDetailsViewModel? details = await animalService.GetAnimalDetailsByIdAsync(animalGuid);

			// Invalid(non-existing) GUID in the URL
			if (details == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(details);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> EditAnimal(string? id)
		{
			Guid animalGuid = Guid.Empty;
			bool isIdValid = IsGuidValid(id, ref animalGuid);
			if (!isIdValid)
			{
				return RedirectToAction(nameof(MyIndex));
			}

			EditAnimalFormModel? model = await animalService.GetEditedModel(animalGuid);

			if (model == null)
			{
				return RedirectToAction(nameof(MyIndex));
			}

			model.AnimalTypes = await animalTypeService.IndexGetAllAnimalTypesAsync();

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> EditAnimal(EditAnimalFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model.AnimalTypes = await animalTypeService.IndexGetAllAnimalTypesAsync();

				return View(model);
			}

			bool isUpdated = await animalService.EditAnimalAsync(model);

			if (!isUpdated)
			{
				ModelState.AddModelError(string.Empty, UpdateAnimalError);
				return View(model);
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> DeleteAnimal(string? id)
		{
			Guid animalGuid = Guid.Empty;
			bool isIdValid = IsGuidValid(id, ref animalGuid);
			if (!isIdValid)
			{
				return RedirectToAction(nameof(Index));
			}

			DeleteAnimalViewModel? animalToDeleteViewModel = await animalService.GetAnimalForDeleteByIdAsync(animalGuid);

			if (animalToDeleteViewModel == null)
			{
				return RedirectToAction(nameof(MyIndex));
			}

			return View(animalToDeleteViewModel);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> SoftDeleteConfirmed(DeleteAnimalViewModel model)
		{
			Guid animalGuid = Guid.Empty;
			bool isIdValid = IsGuidValid(model.Id, ref animalGuid);
			if (!isIdValid)
			{
				return RedirectToAction(nameof(Index));
			}

			bool isInUse = await animalService
				.SoftDeleteAnimalAsync(animalGuid);

			if (!isInUse)
			{
				TempData[nameof(DeleteAnimalError)] = DeleteAnimalError;
				return this.RedirectToAction(nameof(DeleteAnimal), new { id = model.Id });
			}

			return this.RedirectToAction(nameof(MyIndex));
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

			IEnumerable<AnimalIndexViewModel> animals = await animalService.IndexGetAllAnimalsAsync();

			return View(animals);
		}


		private string? GetCurrentUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
