using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RemoteFork.Log.Analytics {
    public static class GAApi {
        public const string TRACKER_ID = "UA-119885832-1";

        private static string anonymUserId;
        private static string AnonymUserId => !string.IsNullOrEmpty(anonymUserId)
            ? anonymUserId
            : (anonymUserId = Guid.NewGuid().ToString());

        public static void TrackEvent(string category, string action, string label) {
            TrackEvent(HitType.@event, category, action, label);
        }

        public static void TrackPageview(string page) {
            TrackPageview(HitType.@pageview, page);
        }

        private static void TrackEvent(HitType type, string category, string action, string label) {
            if (string.IsNullOrEmpty(category)) {
                throw new ArgumentNullException(nameof(category));
            }

            if (string.IsNullOrEmpty(action)) {
                throw new ArgumentNullException(nameof(action));
            }
            
            var postData = new Dictionary<string, string> {
                {"v", "1"},
                {"tid", TRACKER_ID},
                {"cid", AnonymUserId},
                {"t", type.ToString()},
                {"ec", category},
                {"ea", action},
                {"el", label},
            };

            Track(postData);
        }

        private static void TrackPageview(HitType type, string page) {
            if (string.IsNullOrEmpty(page)) {
                throw new ArgumentNullException(nameof(page));
            }
            
            var postData = new Dictionary<string, string> {
                {"v", "1"},
                {"tid", TRACKER_ID},
                {"cid", AnonymUserId},
                {"t", type.ToString()},
                {"dl", page},
            };

            Track(postData);
        }

        private static void Track(Dictionary<string, string> postData) {
            var request = (HttpWebRequest) WebRequest.Create("http://www.google-analytics.com/collect");
            request.Method = "POST";
            string postDataString = postData
                .Aggregate("", (data, next) => string.Format("{0}&{1}={2}", data, next.Key,
                    HttpUtility.UrlEncode(next.Value)))
                .TrimEnd('&');

            // set the Content-Length header to the correct value
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataString);

            // write the request body to the request
            using (var writer = new StreamWriter(request.GetRequestStream())) {
                writer.Write(postDataString);
            }

            try {
                Task.Run(() => request.GetResponseAsync());
            } catch (Exception ex) {
                // do what you like here, we log to Elmah
                // ElmahLog.LogError(ex, "Google Analytics tracking failed");
            }
        }

        private enum HitType {
            // ReSharper disable InconsistentNaming
            @event,
            @pageview,
            // ReSharper restore InconsistentNaming
        }
    }
}
