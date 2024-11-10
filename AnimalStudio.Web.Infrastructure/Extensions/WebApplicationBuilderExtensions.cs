using AnimalStudio.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace AnimalStudio.Web.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddApplicationIdentity(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = configuration
                        .GetValue<bool>("Identity:RequireConfirmedAccount");

                    options.Password.RequireDigit = configuration
                        .GetValue<bool>("Identity:RequireDigit");

                    options.Password.RequireNonAlphanumeric = configuration
                        .GetValue<bool>("Identity:RequireNonAlphanumeric");

                    options.Password.RequireLowercase = configuration
                        .GetValue<bool>("Identity:RequireLowercase");

                    options.Password.RequireUppercase = configuration
                        .GetValue<bool>("Identity:RequireUppercase");
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();


        }
    }
}
