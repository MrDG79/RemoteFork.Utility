using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace RemoteFork.Log.Analytics {
    public class GALoggerProvider : ILoggerProvider {
        private readonly GALoggingConfiguration _config;

        private readonly ConcurrentDictionary<string, GALogger> _loggers =
            new ConcurrentDictionary<string, GALogger>();

        public GALoggerProvider(GALoggingConfiguration config) {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName) {
            return _loggers.GetOrAdd(categoryName, name => new GALogger(name, _config));
        }

        public void Dispose() {
            _loggers.Clear();
        }
    }
}
