using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Animal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimalStudio.Web.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> MyIndex()
        {
            string currentUserId = GetCurrentUserId()!;

            //if (currentUserId == null)
            //{
            //	throw new InvalidOperationException("You are not logged in");
            //}
            IEnumerable<AnimalIndexViewModel> animals = await animalService.IndexGetMyAnimalsAsync(currentUserId);

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

            await animalService.AddAnimalAsync(model);

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

        [HttpPost]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            AnimalDetailsViewModel? model = await animalService.GetAnimalDetailsByIdAsync(id);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAnimal(AnimalDetailsViewModel model)
        {
            await animalService.AnimalDeleteAsync(model);

            return RedirectToAction(nameof(Index));
        }

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
