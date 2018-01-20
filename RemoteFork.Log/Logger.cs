using System;
using System.IO;
using Microsoft.Extensions.Logging;
using RemoteFork.Settings;

namespace RemoteFork.Log {
    public class Logger {
        private static readonly ILoggerFactory LoggerFactory;

        static Logger() {
            LoggerFactory = new LoggerFactory()
                .AddConsole((LogLevel)ProgramSettings.Settings.LogLevel)
                .AddDebug((LogLevel)ProgramSettings.Settings.LogLevel)
#if DEBUG
                .AddFile(Path.Combine(Environment.CurrentDirectory, "Logs/log-{Date}.txt"), isJson: true);
#else
                .AddFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs/log-{Date}.txt"), isJson: true);
#endif
        }

        private readonly ILogger _logger;

        public Logger(string name) {
            _logger = LoggerFactory.CreateLogger(name);
        }

        public Logger(Type type) {
            _logger = LoggerFactory.CreateLogger(type.ToString());
        }

        public void LogInformation(string message) {
            _logger.LogInformation(message);
        }

        public void LogInformation(string format, params object[] args) {
            _logger.LogInformation(format, args);
        }

        public void LogError(string message) {
            _logger.LogError(message);
        }

        public void LogError(string format, params object[] args) {
            _logger.LogError(format, args);
        }

        public void LogError(Exception exception, string message) {
            _logger.LogError(exception, message);
        }

        public void LogError(Exception exception, string format, string message) {
            _logger.LogError(exception, format, message);
        }

        public void LogDebug(string message) {
            _logger.LogDebug(message);
        }

        public void LogDebug(string format, params object[] args) {
            _logger.LogDebug(format, args);
        }
    }
}
