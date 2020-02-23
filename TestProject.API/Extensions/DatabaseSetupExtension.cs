using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TestProject.Data.Context;

namespace TestProject.API.Extensions
{
    public static class DatabaseSetupExtension
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<TestProjectDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
