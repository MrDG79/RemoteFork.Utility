﻿using System.Collections.Specialized;

namespace RemoteFork.Plugins {
    public interface IPluginContext {
        NameValueCollection GetRequestParams();

        string CreatePluginUrl(NameValueCollection parameters);

        string GetLatestVersionNumber(string id);
    }
}
