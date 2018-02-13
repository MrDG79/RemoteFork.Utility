using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RemoteFork.Torrents {
    [Serializable]
    public class TorrentFile {
        [JsonProperty("result")]
        public Dictionary<string, string> Result { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }

    [Serializable]
    public class TorrentId {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("content_id")]
        public string ContentID { get; set; }
    }
}
