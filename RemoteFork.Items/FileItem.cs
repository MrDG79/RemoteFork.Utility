using Newtonsoft.Json;
using RemoteFork.Plugins;

namespace RemoteFork.Items {
    public class FileItem : IItem {
        [JsonProperty("stream_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Link;

        public override string GetLink() {
            return Link;
        }

        public FileItem() : base() {
        }

        public FileItem(FileItem item) : base(item) {
            Link = item.Link;
        }

        public FileItem(Item item) : base(item) {
            Link = item.Link;
        }
    }
}
