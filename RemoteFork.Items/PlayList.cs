using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        public PlayList(IList<IItem> items) {
            Items = new IItem[items.Count];
            for (int i = 0; i < Items.Length; i++) {
                Items[i] = items[i];
            }
        }
    }
}
