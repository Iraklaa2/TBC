using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace TestProject.API.Extensions
{
    public static class LocalizationSetupExtension
    {
        public static void AddLocalizationSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var cultureSetion = configuration.GetSection("AppSettings:Localization");
            var defaultCulture = cultureSetion["DefaultCulture"];
            var systemSupportedCultures = cultureSetion["SupportedCultures"].Split(';');

            services.AddLocalization(opts => 
            { 
                opts.ResourcesPath = "Resources"; 
            });

            services.Configure<RequestLocalizationOptions>(opts => 
            {
                var supportedCultures = new List<CultureInfo>();

                foreach (var culture in systemSupportedCultures)
                    supportedCultures.Add(new CultureInfo(culture));

                opts.DefaultRequestCulture = new RequestCulture(defaultCulture, defaultCulture);
                opts.SupportedCultures = supportedCultures;
                opts.SupportedUICultures = supportedCultures;
            });
        }

        public static void UseLocalizationSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseRequestLocalization();
        }
    }
}
