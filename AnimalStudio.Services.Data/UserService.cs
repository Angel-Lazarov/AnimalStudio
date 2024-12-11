using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Admin.UserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace AnimalStudio.Services.Data
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IRepository<Manager, Guid> managerRepository;

        public UserService(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager, IRepository<Manager, Guid> _managerRepository)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            managerRepository = _managerRepository;

        }

        public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
        {
            IEnumerable<IdentityUser> allUsers = await userManager.Users.ToArrayAsync();
            ICollection<AllUsersViewModel> allUsersViewModel = new List<AllUsersViewModel>();

            foreach (var user in allUsers)
            {
                IEnumerable<string> roles = await userManager.GetRolesAsync(user);

                allUsersViewModel.Add(new AllUsersViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = roles
                });
            }
            return allUsersViewModel;
        }

        public async Task<bool> UserExistsByIdAsync(string userId)
        {
            IdentityUser? user = await userManager.FindByIdAsync(userId);

            return user != null;
        }

        public async Task<bool> AssignUserToRoleAsync(string userId, string role)
        {
            IdentityUser? user = await userManager.FindByIdAsync(userId);

            bool roleExists = await roleManager.RoleExistsAsync(role);

            if (user == null || !roleExists)
            {
                return false;
            }

            bool alreadyInRole = await userManager.IsInRoleAsync(user, role);
            if (!alreadyInRole)
            {
                IdentityResult? result = await userManager
                    .AddToRoleAsync(user, role);
                if (role == "Manager")
                {
                    Manager manager = new Manager()
                    {
                        UserId = userId,
                        NickName = user.UserName!
                    };
                    await managerRepository.AddAsync(manager);
                }

                if (!result.Succeeded)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> RemoveUserRoleAsync(string userId, string roleName)
        {
            IdentityUser? user = await userManager.FindByIdAsync(userId);
            bool roleExists = await roleManager.RoleExistsAsync(roleName);

            if (user == null || !roleExists)
            {
                return false;
            }

            bool alreadyInRole = await userManager.IsInRoleAsync(user, roleName);
            if (alreadyInRole)
            {
                IdentityResult? result = await userManager
                    .RemoveFromRoleAsync(user, roleName);
                if (roleName == "Manager")
                {
                    Manager manager =await managerRepository.FirstOrDefaultAsync(manager => manager.UserId == userId);
                    await managerRepository.DeleteAsync(manager);
                }

                if (!result.Succeeded)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            IdentityUser? user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            IdentityResult? result = await userManager
                .DeleteAsync(user);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }
    }
}
