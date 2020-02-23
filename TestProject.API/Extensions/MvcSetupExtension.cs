using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TestProject.API.Extensions
{
    public static class MvcSetupExtension
    {
        public static void AddMvcSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddMvc(options =>
            {
                 options.EnableEndpointRouting = false;
            });

            // We can add localizations to our DTOs. 

            //.AddDataAnnotationsLocalization(options =>
            // {
            //     options.DataAnnotationLocalizerProvider = (type, factory) =>
            //     {
            //     };
            // });
        }

        public static void UseMvcSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseMvc();
        }
    }
}
