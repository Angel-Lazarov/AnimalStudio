using AnimalStudio.Services.Data;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Animal;
using AnimalStudio.Web.ViewModels.Procedure;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimalStudio.Web.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService animalService;

        public AnimalController(IAnimalService animalService)
        {
            this.animalService = animalService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AnimalIndexViewModel> animals = await animalService.IndexGetAllAnimalAsync();

            return View(animals);
        }


        [HttpGet]
        public IActionResult AddAnimal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(AddAnimalFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string currentUserId = GetCurrentUserId()!;

            await animalService.AddAnimalAsync(currentUserId, model);

            return RedirectToAction(nameof(Index));
        }



        private string? GetCurrentUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}

	}
}
