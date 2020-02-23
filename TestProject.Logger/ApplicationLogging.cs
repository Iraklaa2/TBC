using Microsoft.Extensions.Logging;

namespace TestProject.Logger
{
    public static class ApplicationLogging
    {
        public static ILoggerFactory LoggerFactory { get; set; }

        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
    }
}
