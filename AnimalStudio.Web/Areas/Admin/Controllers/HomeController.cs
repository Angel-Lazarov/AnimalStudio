using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AnimalStudio.Common.ApplicationConstants.RolesConstants;

namespace AnimalStudio.Web.Areas.Admin.Controllers
{
	public class HomeController : Controller
	{
		[Area(AdminRole)]
		[Authorize(Roles = AdminRole)]
		public IActionResult Index()
		{
			return View();
		}
	}
}
