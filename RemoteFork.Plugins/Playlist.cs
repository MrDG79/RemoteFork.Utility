using System;

namespace RemoteFork.Plugins {
    [Obsolete("Playlist, please use PlayList instead.")]
    public class Playlist {
        public static readonly Playlist EmptyPlaylist = new Playlist {
            Items = new Item[0]
        };

        public string source { get; set; }
        public string GetInfo { get; set; }
        public string NextPageUrl { get; set; }

        [Obsolete("IsIptv is deprecated, please use IptvPlaylist instead.")]
        public string IsIptv { get; set; }

        public bool IptvPlaylist { get; set; }
        public string Timeout { get; set; }
        public Item[] Items { get; set; }
    }
}
