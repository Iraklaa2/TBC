using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestProject.API.Extensions;
using TestProject.Logger;

namespace TestProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalizationSetup(Configuration);

            // CORS Config
            services.AddCorsSetup(Configuration);

            // Auto mappers
            services.AddAutoMappingSetupSetup();

            // Add controllers
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Setting DBContext
            services.AddDatabaseSetup(Configuration);

            // Swagger Config
            services.AddSwaggerSetup();

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add application services
            services.AddServicesSetup();

            // Add Mvc
            services.AddMvcSetup(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.UseLoggerSetup();
            ApplicationLogging.LoggerFactory = loggerFactory;

            app.UseLocalizationSetup();

            app.UseCorsSetup();

            app.UseMiddlewaresSetup();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();

            app.UseMvcSetup();
        }
    }
}
