using System;
using Newtonsoft.Json;

namespace RemoteFork.Items {
    [Serializable]
    public class DirectoryItem : IItem {
        [JsonProperty("playlist_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Link;

        public override string GetLink() {
            return Link;
        }

        public DirectoryItem() : base() {
        }

        public DirectoryItem(DirectoryItem item) : base(item) {
            Link = item.Link;
        }
    }
}
