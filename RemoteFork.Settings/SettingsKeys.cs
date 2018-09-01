namespace RemoteFork.Settings {
    public enum FilterMode : byte {
        NONE = 0,
        INCLUSION = 1,
        EXCLUSION = 2
    }
    public enum ProxyType : byte {
        HTTP = 0,
        SOCKS4 = 1,
        SOCKS4A = 2,
        SOCKS5 = 3
    }
}
