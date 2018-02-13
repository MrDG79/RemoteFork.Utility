using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RemoteFork.Network;

namespace RemoteFork.Torrents {
    public class FileList {
        public static Dictionary<string, string> GetFileListByTorrentLink(string torrentLink, Dictionary<string,string> header = null) {
            byte[] response = HTTPUtility.GetBytesRequest(torrentLink, header);
            return GetFileListByTorrentData(response);
        }

        public static Dictionary<string, string> GetFileListByTorrentData(byte[] torrentData) {
            return GetFileList(GetContentId(torrentData), "content_id");
        }

        public static string GetContentId(byte[] torrentData) {
            return GetContentId(Convert.ToBase64String(torrentData));
        }

        public static string GetContentId(string torrentData) {
            string response = HTTPUtility.PostRequest("http://api.torrentstream.net/upload/raw",
                Encoding.UTF8.GetBytes(torrentData));
            var content = JsonConvert.DeserializeObject<TorrentId>(response);
            if (string.IsNullOrEmpty(content.Error)) {
                return content.ContentID;
            }
            return response;
        }

        public static Dictionary<string, string> GetFileList(string key, string type) {
            string aceMadiaInfo =
                HTTPUtility.GetRequest(string.Format("{0}/server/api?method=get_media_files&{1}={2}",
                    AceStreamEngine.GetServer, type, key));
            if (!string.IsNullOrWhiteSpace(aceMadiaInfo)) {
                var files = JsonConvert.DeserializeObject<TorrentFile>(aceMadiaInfo);
                if (string.IsNullOrEmpty(files.Error)) {
                    return files.Result;
                }
            }

            return new Dictionary<string, string>();
        }
    }
}
