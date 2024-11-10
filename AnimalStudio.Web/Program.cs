using AnimalStudio.Data;
using AnimalStudio.Web.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AnimalStudio.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //var connectionString = builder.Configuration.GetConnectionString("WorkConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            var connectionString = builder.Configuration.GetConnectionString("HomeConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddApplicationIdentity(builder.Configuration);
            //builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            //    {
            //        options.SignIn.RequireConfirmedAccount = false;
            //        options.Password.RequireLowercase = false;
            //        options.Password.RequireDigit = false;
            //        options.Password.RequireUppercase = false;
            //        options.Password.RequireLowercase = false;
            //        options.Password.RequireNonAlphanumeric = false;
            //    })
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

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
    }
}
