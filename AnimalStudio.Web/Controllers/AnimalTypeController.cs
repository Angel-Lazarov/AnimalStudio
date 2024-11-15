using AnimalStudio.Services.Data;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.AnimalType;
using AnimalStudio.Web.ViewModels.Worker;
using Microsoft.AspNetCore.Mvc;

namespace AnimalStudio.Web.Controllers
{
    public class AnimalTypeController : Controller
    {
        private readonly IAnimalTypeService animalTypeService;

        public AnimalTypeController(IAnimalTypeService animalTypeService)
        {
            this.animalTypeService = animalTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AnimalTypeViewModel> animalTypesList = await animalTypeService.IndexGetAllAnimalTypesAsync();

            return View();
        }

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

            return View();
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
    }
}
