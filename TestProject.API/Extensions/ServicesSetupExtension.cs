using Microsoft.Extensions.DependencyInjection;
using System;
using TestProject.Application.Contracts;
using TestProject.Application.Services;
using TestProject.Data.Repositories;
using TestProject.Domain.Contracts;

namespace TestProject.API.Extensions
{
    public static class ServicesSetupExtension
    {
        public static void AddServicesSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            
            // Services
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IRelatedPersonService, RelatedPersonService>();
            services.AddScoped<ICityService, CityService>();

            // Repositories
            services.AddScoped<IRelatedPersonRepository, RelatedPersonRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            // UoW
            services.AddScoped<IUnitOfWork, Data.UoW.UnitOfWork>();
        }
    }
}
