using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Admin.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AnimalStudio.Common.ApplicationConstants.RolesConstants;

namespace AnimalStudio.Web.Areas.Admin.Controllers
{
	[Area(AdminRole)]
	[Authorize(Roles = AdminRole)]
	public class UserManagementController : Controller
	{
		private readonly IUserService userService;

		public UserManagementController(IUserService _userService)
		{
			userService = _userService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<AllUsersViewModel> allUsers = await userService.GetAllUsersAsync();
			return View(allUsers);
		}

		[HttpPost]
		public async Task<IActionResult> AssignRole(string userId, string role)
		{
			bool userExists = await userService.UserExistsByIdAsync(userId);
			if (!userExists)
			{
				return RedirectToAction(nameof(Index));
			}

			bool assignResult = await userService.AssignUserToRoleAsync(userId, role);

			if (!assignResult)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> RemoveRole(string userId, string role)
		{
			bool userExists = await userService.UserExistsByIdAsync(userId);
			if (!userExists)
			{
				return RedirectToAction(nameof(Index));
			}

			bool removeResult = await userService.RemoveUserRoleAsync(userId, role);

			if (!removeResult)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> DeleteUser(string userId)
		{
			bool userExists = await userService.UserExistsByIdAsync(userId);
			if (!userExists)
			{
				return this.RedirectToAction(nameof(Index));
			}

			bool removeResult = await userService.DeleteUserAsync(userId);
			if (!removeResult)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}
	}
}