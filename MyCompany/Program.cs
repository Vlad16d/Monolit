using Microsoft.AspNetCore.Builder;
using MyCompany.Infrastructure;
// to jest przyk³adowy komentarz
namespace MyCompany
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Adding a file appsettings.json to the configuration 
            IConfigurationBuilder configBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            // Wrapping the Project section in an object form for comfort
            IConfiguration configuration = configBuild.Build();
            AppConfig config = configuration.GetSection("Project ").Get<AppConfig>()!;

            // Connecting controller functionality
            builder.Services.AddControllersWithViews();

            // Build configuration
            WebApplication app = builder.Build();

            // Enabling the use of static files (js, css, ...)
            app.UseStaticFiles();

            // Connecting the routing system
            app.UseRouting();

            // Registration of necessary routes
            app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync();

        }
    }
}
