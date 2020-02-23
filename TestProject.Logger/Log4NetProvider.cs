using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Xml;

namespace TestProject.Logger
{
    public sealed class Log4NetProvider : ILoggerProvider
    {
        private readonly string _log4NetConfigFile;

        private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers;

        public Log4NetProvider(string log4NetConfigFile)
        {
            _loggers = new ConcurrentDictionary<string, Log4NetLogger>();
            _log4NetConfigFile = log4NetConfigFile;
        }

        private static XmlElement Parselog4NetConfigFile(string filename)
        {
            XmlDocument log4netConfig = new XmlDocument();
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            string textPath = Path.Combine(assemblyDirectory, filename);


            log4netConfig.Load(File.OpenRead(textPath));

            return log4netConfig["log4net"];
        }

        public ILogger CreateLogger(string categoryName) => _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);

        private Log4NetLogger CreateLoggerImplementation(string name) => new Log4NetLogger(name, Parselog4NetConfigFile(_log4NetConfigFile));

        public void Dispose() => _loggers.Clear();
    }
}
