using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AnimalStudio.Web.Controllers
{
	public class BaseController : Controller
	{
		protected readonly IManagerService managerService;
		public BaseController(IManagerService managerService)
		{
			this.managerService = managerService;
		}

		protected bool IsGuidValid(string? id, ref Guid parsedGuid)
		{
			// Non-existing parameter in the URL
			if (String.IsNullOrWhiteSpace(id))
			{
				return false;
			}

			// Invalid parameter in the URL
			bool isGuidValid = Guid.TryParse(id, out parsedGuid);
			if (!isGuidValid)
			{
				return false;
			}

			return true;
		}

		protected async Task<bool> IsUserManagerAsync()
		{
			string? userId = this.User.GetUserId();
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId);

			return isManager;
		}
	}
}
