using Newtonsoft.Json;

namespace RemoteFork.Settings {
    public class Settings {
        [JsonProperty(SettingsKey.IP_ADDRESS)]
        public string IpAddress { get; set; }
        [JsonProperty(SettingsKey.PORT)]
        public ushort Port { get; set; }
        [JsonProperty(SettingsKey.LISTEN_LOCALHOST)]
        public bool ListenLocalhost { get; set; }

        [JsonProperty(SettingsKey.USE_PROXY)]
        public bool UseProxy { get; set; }
        [JsonProperty(SettingsKey.PROXY_NOT_DEFAULT_ENABLE)]
        public bool ProxyNotDefaultEnable { get; set; }
        [JsonProperty(SettingsKey.PROXY_ADDRESS)]
        public string ProxyAddress { get; set; }
        [JsonProperty(SettingsKey.PROXY_USER_NAME)]
        public string ProxyUserName { get; set; }
        [JsonProperty(SettingsKey.PROXY_PASSWORD)]
        public string ProxyPassword { get; set; }

        [JsonProperty(SettingsKey.USER_AGENT)]
        public string UserAgent { get; set; }

        [JsonProperty(SettingsKey.DLNA)]
        public bool Dlna { get; set; }
        [JsonProperty(SettingsKey.DLNA_FILTER_TYPE)]
        public FilterMode DlnaFilterType { get; set; }
        [JsonProperty(SettingsKey.DLNA_DIRECTORIES)]
        public string[] DlnaDirectories { get; set; }
        [JsonProperty(SettingsKey.DLNA_FILE_EXTENSIONS)]
        public string[] DlnaFileExtensions { get; set; }

        [JsonProperty(SettingsKey.PLUGINS)]
        public bool Plugins { get; set; }
        [JsonProperty(SettingsKey.ENABLE_PLUGINS)]
        public string[] EnablePlugins { get; set; }

        [JsonProperty(SettingsKey.USER_URLS)]
        public string[] UserUrls { get; set; }
        
        [JsonProperty(SettingsKey.ACE_STREAM_PORT)]
        public ushort AceStreamPort { get; set; }

        [JsonProperty(SettingsKey.LOG_LEVEL)]
        public byte LogLevel { get; set; }
        [JsonProperty(SettingsKey.CHECK_UPDATE)]
        public bool CheckUpdate { get; set; }
        [JsonProperty(SettingsKey.DEVELOPER_MODE)]
        public bool DeveloperMode { get; set; }

        public string UID { get; set; }
    }
}
