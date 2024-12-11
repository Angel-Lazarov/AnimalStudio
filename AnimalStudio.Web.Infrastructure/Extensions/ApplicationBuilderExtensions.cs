using AnimalStudio.Common;
using AnimalStudio.Data;
using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static AnimalStudio.Common.ApplicationConstants.AdminConstants;
using static AnimalStudio.Common.ApplicationConstants.RolesConstants;
using static AnimalStudio.Common.ExceptionMessages.AdminExceptionMessages;
using static AnimalStudio.Common.ExceptionMessages.ManagerExceptionMessages;
using static AnimalStudio.Common.ExceptionMessages.RoleExceptionMessages;

namespace AnimalStudio.Web.Infrastructure.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder CreateRolesAsync(this IApplicationBuilder app)
		{
			IServiceScope serviceScope = app.ApplicationServices.CreateScope();

			RoleManager<IdentityRole> roleManager = serviceScope
				.ServiceProvider
				.GetRequiredService<RoleManager<IdentityRole>>();

			IList<string> roles = new List<string>()
			{
				AdminRole,
				ApplicationConstants.RolesConstants.Manager,
				User
			};

			foreach (string role in roles)
			{
				bool roleExists = roleManager.RoleExistsAsync(role).GetAwaiter().GetResult();
				if (!roleExists)
				{
					IdentityResult result = roleManager.CreateAsync(new IdentityRole(role)).GetAwaiter().GetResult();
					if (!result.Succeeded)
					{
						throw new Exception($"{CreateRoleExceptionMessage} {role}");
					}
				}
			}
			return app;
		}

		public static IApplicationBuilder CreateAdminUserAsync(this IApplicationBuilder app)
		{
			using IServiceScope serviceScope = app.ApplicationServices.CreateAsyncScope();

			UserManager<IdentityUser> userManager = serviceScope
				.ServiceProvider
				.GetRequiredService<UserManager<IdentityUser>>();

			IRepository<Manager, Guid> managerRepository = serviceScope
				.ServiceProvider.GetRequiredService<IRepository<Manager, Guid>>();

			if (userManager == null)
			{
				throw new ArgumentNullException(nameof(userManager),
					$"Service for {typeof(UserManager<IdentityUser>)} cannot be obtained!");
			}

			Task.Run(async () =>
			{
				IdentityUser? existentUser = await userManager
					.FindByEmailAsync(AdminEmail);

				if (existentUser == null)
				{
					IdentityUser identityUser = new IdentityUser()
					{
						Email = AdminEmail,
						UserName = AdminEmail,
					};

					IdentityResult result = await userManager
						.CreateAsync(identityUser, AdminPassword);

					if (!result.Succeeded)
					{
						throw new Exception(AdminUserCreationFailedExceptionMessage);
					}
					else
					{
						IdentityUser? adminUser = await userManager
							.FindByEmailAsync(AdminEmail);

						if (adminUser == null)
						{
							throw new Exception(AdminUserNotFoundExceptionMessage);
						}

						if (await userManager.IsInRoleAsync(adminUser, AdminRole))
						{
							return app;
						}

						IdentityResult adminResult = await userManager.AddToRoleAsync(adminUser, AdminRole);
						if (!adminResult.Succeeded)
						{
							throw new InvalidOperationException(AdminUserNotAddedToRoleExceptionMessage);
						}

						if (await userManager.IsInRoleAsync(adminUser, ApplicationConstants.RolesConstants.Manager))
						{
							return app;
						}
						IdentityResult managerResult = await userManager.AddToRoleAsync(adminUser, ApplicationConstants.RolesConstants.Manager);

						Manager manager = new Manager()
						{
							UserId = adminUser.Id,
							NickName = adminUser.UserName!
						};
						await managerRepository.AddAsync(manager);

						if (!managerResult.Succeeded)
						{
							throw new InvalidOperationException(AdminUserNotAddedToManagerRoleExceptionMessage);
						}
					}
				}
				return app;
			})
				.GetAwaiter()
				.GetResult();

			return app;
		}

		public static void AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDefaultIdentity<IdentityUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = configuration
						.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

				options.SignIn.RequireConfirmedEmail = configuration
					.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");

				options.Password.RequireDigit = configuration
					.GetValue<bool>("Identity:Password:RequireDigit");

				options.Password.RequireNonAlphanumeric = configuration
					.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

				options.Password.RequireLowercase = configuration
					.GetValue<bool>("Identity:Password:RequireLowercase");

				options.Password.RequireUppercase = configuration
					.GetValue<bool>("Identity:Password:RequireUppercase");


				options.Password.RequiredLength = configuration
					.GetValue<int>("Identity:Password:RequiredLength");

				options.Password.RequiredUniqueChars = configuration
					.GetValue<int>("Identity:Password:RequiredUniqueChars");
			})
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
		}
	}
}
