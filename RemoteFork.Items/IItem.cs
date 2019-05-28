using System;
using Newtonsoft.Json;

namespace RemoteFork.Items {
    [Serializable]
    public abstract class IItem {
        [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title;

        [JsonProperty("logo_30x30", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ImageLink;

        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Description;

        [JsonProperty("get_info", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string GetInfo;

        public abstract string GetLink();

        protected IItem() {
        }

        protected IItem(IItem item) {
            Title = item.Title;
            ImageLink = item.ImageLink;
            Description = item.Description;
            GetInfo = item.GetInfo;
        }
    }
}
