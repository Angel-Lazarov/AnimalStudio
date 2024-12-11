using AnimalStudio.Data;
using AnimalStudio.Data.Models;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			//var connectionString = builder.Configuration.GetConnectionString("WorkConnection") ?? throw new InvalidOperationException("Connection string 'defaultConnection' not found.");
			var connectionString = builder.Configuration.GetConnectionString("HomeConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			builder.Services.AddApplicationIdentity(builder.Configuration);

			builder.Services.AddControllersWithViews(cfg =>
			{
				cfg.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
			});


			builder.Services.RegisterRepositories(typeof(Procedure).Assembly);
			builder.Services.RegisterUserDefinedServices(typeof(IProcedureService).Assembly);

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

			app.Use((context, next) =>
			{
				if (context.User.Identity?.IsAuthenticated == true && context.Request.Path == "/")
				{
					if (context.User.IsInRole("Admin"))
					{
						context.Response.Redirect("/Admin/Home/Index");
						return Task.CompletedTask;

					}
				}
				return next();
			});

			app.UseAuthorization();

			app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");

			app.CreateRolesAsync();
			app.CreateAdminUserAsync();

			app.MapControllerRoute(
				name: "Areas",
				pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();
		}
	}
}
