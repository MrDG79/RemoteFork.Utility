using System;
using Newtonsoft.Json;
using RemoteFork.Plugins;

namespace RemoteFork.Items {
    [Serializable]
    public class SearchItem : DirectoryItem {
        [JsonProperty("search_on", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public readonly string SearchOn = "search_on";

        public SearchItem():base() {
        }

        public SearchItem(SearchItem item):base(item) {
        }

        public SearchItem(Item item) : base(item) {
        }
    }
}
