using System;
using System.Collections.Generic;
using RemoteFork.Items;

namespace RemoteFork.Plugins.Items.Converter {
    [Serializable]
    public class PlayList : RemoteFork.Items.PlayList {
        public PlayList(Playlist playlist) {
            Source = playlist.source;
            NextPageUrl = playlist.NextPageUrl;
            GetInfo = playlist.GetInfo;
            Timeout = playlist.Timeout;

            IsIptv = playlist.IptvPlaylist ||
                     (!string.IsNullOrEmpty(playlist.IsIptv) && playlist.IsIptv.ToLower() == true.ToString());

            if (playlist.Items != null) {
                Items = new List<IItem>(playlist.Items.Length);

                for (int i = 0; i < playlist.Items.Length; i++) {
                    Items[i] = ConvertItem(playlist.Items[i]);
                }
            }
        }

        public PlayList(IList<Item> items) {
            Items = new List<IItem>(items.Count);

            for (int i = 0; i < Items.Count; i++) {
                Items[i] = ConvertItem(items[i]);
            }
        }

        public static IItem ConvertItem(Item sourceItem) {
            IItem destinationItem = null;

            if (!string.IsNullOrEmpty(sourceItem.SearchOn)) {
                sourceItem.Type = ItemType.SEARCH;
            }

            switch (sourceItem.Type) {
                case ItemType.DIRECTORY: {
                    var tempItem = new DirectoryItem { Link = sourceItem.Link };

                    destinationItem = tempItem;
                }
                    break;
                case ItemType.FILE: {
                    var tempItem = new FileItem { Link = sourceItem.Link };

                    destinationItem = tempItem;
                }
                    break;
                case ItemType.SEARCH: {
                    var tempItem = new SearchItem { Link = sourceItem.Link };

                    destinationItem = tempItem;
                }
                    break;
            }

            if (destinationItem != null) {
                destinationItem.Title = sourceItem.Name;
                destinationItem.Description = sourceItem.Description;
                destinationItem.ImageLink = sourceItem.ImageLink;
                destinationItem.GetInfo = sourceItem.GetInfo;
            }

            return destinationItem;
        }
    }
}
