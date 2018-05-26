using Microsoft.Extensions.Logging;

namespace RemoteFork.Log.Analytics {
    public class GALoggingConfiguration {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
    }
}