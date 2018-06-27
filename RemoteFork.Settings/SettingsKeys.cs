namespace RemoteFork.Settings {
    public static class SettingsKey {
        public const string IP_ADDRESS = "IpIPAddress";
        public const string PORT = "Port";
        public const string LISTEN_LOCALHOST = "ListemLocalhost";

        public const string USE_PROXY = "UseProxy";
        public const string PROXY_NOT_DEFAULT_ENABLE = "PROXY_NOT_DEFAULT_ENABLE";
        public const string PROXY_ADDRESS = "ProxyAddress";
        public const string PROXY_USER_NAME = "ProxyUserName";
        public const string PROXY_PASSWORD = "ProxyPassword";

        public const string USER_AGENT = "UserAgent";

        public const string DLNA = "Dlna";
        public const string DLNA_FILTER_TYPE = "DlnaFilterType";
        public const string DLNA_DIRECTORIES = "DlnaDirectories";
        public const string DLNA_FILE_EXTENSIONS = "DlnaFileExtensions";

        public const string PLUGINS = "Plugins";
        public const string ENABLE_PLUGINS = "EnablePlugins";

        public const string USER_URLS = "UserUrls";
        
        public const string ACE_STREAM_PORT = "AceStreamPort";

        public const string LOG_LEVEL = "LogLevel";
        public const string CHECK_UPDATE = "CheckUpdate";
        public const string DEVELOPER_MODE = "DeveloperMode";
    }

    public enum FilterMode : byte {
        NONE = 0,
        INCLUSION = 1,
        EXCLUSION = 2
    }
}
