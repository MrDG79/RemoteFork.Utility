using System.Collections.Generic;
using Newtonsoft.Json;

namespace RemoteFork.Items {
    public static class ResponseManager {
        public static string CreateResponse(IList<IItem> items) {
            var playList = new PlayList(items);

            return CreateResponse(playList);
        }

        public static string CreateResponse(PlayList playList) {
            return JsonConvert.SerializeObject(playList);
        }
    }
}
