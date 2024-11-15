using AnimalStudio.Data;
using AnimalStudio.Data.Models;
using AnimalStudio.Services.Data;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("WorkConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			//var connectionString = builder.Configuration.GetConnectionString("HomeConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			builder.Services.AddDefaultIdentity<IdentityUser>(options =>
				{
					ConfigureIdentity(builder, options);
				})
				.AddEntityFrameworkStores<ApplicationDbContext>();

			builder.Services.AddControllersWithViews();


			builder.Services.RegisterRepositories(typeof(Procedure).Assembly);


			builder.Services.AddScoped<IWorkerService, WorkerService>();
			builder.Services.AddScoped<IProcedureService, ProcedureService>();
			builder.Services.AddScoped<IAnimalTypeService, AnimalTypeService>();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();
		}

		private static void ConfigureIdentity(WebApplicationBuilder builder, IdentityOptions options)
		{
			//SignIn Settings
			options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
			options.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");
			options.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");

			//Password Settings
			options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
			options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:Password:RequireDigit");
			options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
			options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
			options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
			options.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("Identity:Password:RequiredUniqueChars");

			//Lockout Settings
			options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
			options.Lockout.MaxFailedAccessAttempts = builder.Configuration.GetValue<int>("Identity:Lockout:MaxFailedAccessAttempts");
			options.Lockout.AllowedForNewUsers = builder.Configuration.GetValue<bool>("Identity:Lockout:AllowedForNewUsers");

			//User Settings
			options.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
		}

	}
}
