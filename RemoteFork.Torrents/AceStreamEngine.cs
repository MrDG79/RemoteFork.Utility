using RemoteFork.Settings;

namespace RemoteFork.Torrents {
    public class AceStreamEngine {
        public static string GetServer =>
            $"http://{ProgramSettings.Settings.IpAddress}:{ProgramSettings.Settings.AceStreamPort}";
    }
}
