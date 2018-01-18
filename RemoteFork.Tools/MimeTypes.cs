using System;
using HeyRed.Mime;

namespace RemoteFork.Tools {
    public static class MimeTypes {
        public static string Get(string fileName) {
            return MimeTypesMap.GetMimeType(fileName);
        }

        public static bool ContainsKey(string fileName) {
            try {
                return !string.IsNullOrWhiteSpace(Get(fileName));
            } catch (Exception exception) {
                return false;
            }
        }
    }
}
