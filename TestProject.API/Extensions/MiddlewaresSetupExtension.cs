using Microsoft.AspNetCore.Builder;
using System;
using TestProject.API.Middlewares;

namespace TestProject.API.Extensions
{
    public static class MiddlewaresSetupExtension
    {
        public static void UseMiddlewaresSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
