using Microsoft.AspNetCore.Mvc;

namespace AnimalStudio.Web.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAnimal()
        {
            return View();
        }
    }
}
