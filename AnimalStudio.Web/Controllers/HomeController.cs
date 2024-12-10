using AnimalStudio.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnimalStudio.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		[Route("/Home/Error/{statusCode}")]
		public IActionResult Error(int? statusCode = null)
		{
			if (!statusCode.HasValue)
			{
				return View();
			}

			if (statusCode == 404)
			{

				return View("Error404");
			}

			if (statusCode == 401)
			{
				return this.View("Error401");
			}

			if (statusCode == 403)
			{
				return View("Error403");
			}

			return this.View("Error500");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
