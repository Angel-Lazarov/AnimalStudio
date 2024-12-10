using AnimalStudio.Web.ViewModels.Admin.UserManagement;

namespace AnimalStudio.Services.Data.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();

		Task<bool> UserExistsByIdAsync(string userId);

		Task<bool> AssignUserToRoleAsync(string userId, string role);

		Task<bool> RemoveUserRoleAsync(string userId, string role);

		Task<bool> DeleteUserAsync(string userId);
	}
}
