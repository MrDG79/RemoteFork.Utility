using System;
using Microsoft.Extensions.Logging;

namespace RemoteFork.Log.Analytics {
    public class GALogger : ILogger {
        private readonly string _name;
        private readonly GALoggingConfiguration _config;

        public GALogger(string name, GALoggingConfiguration config) {
            _name = name;
            _config = config;
        }

        public IDisposable BeginScope<TState>(TState state) {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel) {
            return logLevel == _config.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter) {
            if (!IsEnabled(logLevel)) {
                return;
            }

            GAApi.TrackEvent(logLevel.ToString(), _name, $"{formatter(state, exception)}");
        }
    }
}
