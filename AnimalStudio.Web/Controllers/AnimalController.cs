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
		public async Task<IActionResult> MyIndex()
		{
			string currentUserId = GetCurrentUserId()!;

			IEnumerable<AnimalDetailsViewModel> animals = await animalService.IndexGetMyAnimalsAsync(currentUserId);

			return View(animals);
		}

		[HttpGet]
		public async Task<IActionResult> AddAnimal()
		{
			string currentUserId = GetCurrentUserId()!;

			if (currentUserId == null)
			{
				throw new InvalidOperationException("You are not logged in");
			}

			AddAnimalFormModel model = new AddAnimalFormModel()
			{
				AnimalTypes = await animalTypeService.IndexGetAllAnimalTypesAsync(),
				UserId = currentUserId
			};

			return View(model);
		}

		[HttpPost]
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

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> AnimalDetails(int id)
		{
			AnimalDetailsViewModel? details = await animalService.GetAnimalDetailsByIdAsync(id);

			if (details == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(details);
		}

		[HttpGet]
		public async Task<IActionResult> EditAnimal(int id)
		{
			EditAnimalFormModel? model = await animalService.GetEditedModel(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			model.AnimalTypes = await animalTypeService.IndexGetAllAnimalTypesAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditAnimal(EditAnimalFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model.AnimalTypes = await animalTypeService.IndexGetAllAnimalTypesAsync();

				return View(model);
			}

			await animalService.EditAnimalAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> DeleteAnimal(int id)
		{
			bool result = await animalService.AnimalDeleteAsync(id);

			if (result == false)
			{
				TempData[nameof(AnimalIsInUse)] = AnimalIsInUse;
				return RedirectToAction("Index", "Order");
			}

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

			IEnumerable<AnimalIndexViewModel> animals = await animalService.IndexGetAllAnimalsAsync();

			return View(animals);
		}


		private string? GetCurrentUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
