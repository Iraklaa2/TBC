using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using TestProject.Application.AutoMapper;

namespace TestProject.API.Extensions
{
    public static class AutoMappingSetupExtension
    {
        public static void AddAutoMappingSetupSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EntityToDTOMappingProfile());
                mc.AddProfile(new DtoToEntityMappingProfile());
                mc.AddProfile(new DtoToFilterModelMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
