namespace RemoteFork.Settings {
    public class AbstractSettings<T> {
        public static T Settings { get; protected set; }
        public SettingsManager<T> SettingsManager { get; }

        protected static T defaultSettings;
        protected static string fileName;

        public AbstractSettings() {
            SettingsManager = new SettingsManager<T>(fileName);
            if (SettingsManager.Settings == null) {
                SettingsManager.Save(defaultSettings);
            }
            Settings = SettingsManager.Settings;
        }
    }
}
