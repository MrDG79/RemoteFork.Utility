using System.Net;

namespace RemoteFork.Settings {
    public class ProgramSettings : AbstractSettings<ProgramSettings, Settings> {
        static ProgramSettings() {
            fileName = "Settings.json";
            defaultSettings = DefaultSettings;
        }

        private static Settings DefaultSettings { get; } = new Settings() {
            IpAddress = IPAddress.Parse("0.0.0.0").ToString(),
            Port = (ushort) 8027,
            ListenLocalhost = true,
            UseProxy = false,
            ProxyType = ProxyType.HTTP,
            ProxyNotDefaultEnable = false,

            UserAgent =
                "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36",

            Dlna = false,
            DlnaFilterType = FilterMode.NONE,
            DlnaDirectories = (new string[0]),
            DlnaFileExtensions = (new string[0]),

            Plugins = true,
            EnablePlugins = new string[0],

            UserUrls = new string[0],

            AceStreamPort = (ushort)6878,

            LogLevel = (byte)5,
            CheckUpdate = true,
            DeveloperMode = false,

            StartPageModernStyle = false
        };
    }
}
