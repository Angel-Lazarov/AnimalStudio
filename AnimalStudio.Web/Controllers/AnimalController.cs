using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Animal;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimalStudio.Web.Controllers
{
	public class AnimalController : Controller
	{
		private readonly IAnimalService animalService;
		private readonly IAnimalTypeService animalTypeService;

		public AnimalController(IAnimalService animalService, IAnimalTypeService animalTypeService)
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
		public async Task<IActionResult> AddAnimal()
		{
			AddAnimalFormModel model = new AddAnimalFormModel()
			{
				AnimalTypes = await animalTypeService.IndexGetAllAnimalTypesAsync(),
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

			string currentUserId = GetCurrentUserId()!;

			if (currentUserId == null)
			{
				throw new InvalidOperationException("You are not logged in");
			}

			await animalService.AddAnimalAsync(currentUserId, model);

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



		private string? GetCurrentUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
