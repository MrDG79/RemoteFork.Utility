using Newtonsoft.Json;

namespace RemoteFork.Settings {
    public class Settings {
        public string IpAddress { get; set; }
        public ushort Port { get; set; }
        public bool ListenLocalhost { get; set; }
        
        public bool UseProxy { get; set; }
        public bool ProxyNotDefaultEnable { get; set; }
        public string ProxyAddress { get; set; }
        public int ProxyPort{ get; set; }
        public string ProxyUserName { get; set; }
        public string ProxyPassword { get; set; }
        public ProxyType ProxyType { get; set; }
        
        public string UserAgent { get; set; }
        
        public bool Dlna { get; set; }
        public FilterMode DlnaFilterType { get; set; }
        public string[] DlnaDirectories { get; set; }
        public string[] DlnaFileExtensions { get; set; }
        
        public bool Plugins { get; set; }
        public string[] EnablePlugins { get; set; }
        
        public string[] UserUrls { get; set; }
        
        public ushort AceStreamPort { get; set; }
        
        public byte LogLevel { get; set; }
        public bool CheckUpdate { get; set; }
        public bool DeveloperMode { get; set; }

        public bool StartPageModernStyle { get; set; }

        public string UID { get; set; }
    }
}
