using LibraryAPI.Infrastructor;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LibraryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build()
                .EnsureMigrationsandPopulate()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
