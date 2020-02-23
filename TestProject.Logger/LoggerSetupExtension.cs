using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace TestProject.Logger
{
    public static class LoggerSetupExtension
    {
        public static ILoggingBuilder UseLoggerSetup(this ILoggingBuilder builder, string log4NetConfigFile = "log4net.config")
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider>(new Log4NetProvider(log4NetConfigFile)));
            return builder;
        }

        public static ILoggerFactory UseLoggerSetup(this ILoggerFactory factory, string log4NetConfigFile = "log4net.config")
        {
            factory.AddProvider(new Log4NetProvider(log4NetConfigFile));
            return factory;
        }
    }
}
