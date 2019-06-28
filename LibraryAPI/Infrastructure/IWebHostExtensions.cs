using LibraryAPI.EF_DBLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Infrastructure
{
    public static class IWebHostExtensions
    {
        public static IWebHost EnsureMigrationsandPopulate(this IWebHost host)
        {
            using (var scope = host.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    context.Database.Migrate();
                }
            }
            return host;
        }
    }
}
