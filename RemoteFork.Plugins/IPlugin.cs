using System;
using RemoteFork.Items;

namespace RemoteFork.Plugins {
    [Obsolete("interface IPlugin, please use IRemotePlugin instead.")]
    public interface IPlugin {
        Playlist GetList(IPluginContext context);
    }

    public interface IRemotePlugin {
        PlayList GetPlayList(IPluginContext context);
    }
}
