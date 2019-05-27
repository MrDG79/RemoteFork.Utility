using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RemoteFork.Plugins;

namespace RemoteFork.Items {
    [Serializable]
    public class PlayList {
        public string Source { get; set; }

        [JsonProperty("playlist_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PlaylistName;

        [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title;

        [JsonProperty("navigate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Navigate;

        [JsonProperty("icon", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Icon;

        [JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Url;

        [JsonProperty("channels", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IItem[] Items;

        [JsonProperty("next_page_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string NextPageUrl;

        [JsonProperty("get_info", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string GetInfo;

        [JsonProperty("is_iptv", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsIptv;

        [JsonProperty("timeout", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Timeout;

        public PlayList() {

        }

        public PlayList(Playlist playlist) {
            Source = playlist.source;
            NextPageUrl = playlist.NextPageUrl;
            GetInfo = playlist.GetInfo;
            Timeout = playlist.Timeout;

            IsIptv = playlist.IptvPlaylist || !string.IsNullOrEmpty(playlist.IsIptv);

            if (playlist.Items != null) {
                Items = new IItem[playlist.Items.Length];

                for (int i = 0; i < Items.Length; i++) {
                    Items[i] = ConvertItem(playlist.Items[i]);
                }
            }
        }

        public PlayList(IList<IItem> items) {
            Items = new IItem[items.Count];
            for (int i = 0; i < Items.Length; i++) {
                Items[i] = items[i];
            }
        }

        public PlayList(IList<Item> items) {
            Items = new IItem[items.Count];
            for (int i = 0; i < Items.Length; i++) {
                Items[i] = ConvertItem(items[i]);
            }
        }

        public IItem ConvertItem(Item item) {
            switch (item.Type) {
                case ItemType.DIRECTORY:
                    return new DirectoryItem(item);
                case ItemType.FILE:
                    return new FileItem(item);
                case ItemType.SEARCH:
                    return new SearchItem(item);
            }

            return null;
        }
    }
}
