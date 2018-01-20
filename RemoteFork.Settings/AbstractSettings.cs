namespace RemoteFork.Settings {
    public class AbstractSettings<TM, TS> where TM : AbstractSettings<TM, TS>, new() {
        private static TM _instance;
        public static TM Instance => _instance ?? (_instance = new TM());
        public static TS Settings => Instance._settings;

        protected TS _settings { get; }
        protected SettingsManager<TS> settingsManager { get; }

        protected static TS defaultSettings;
        protected static string fileName;

        protected AbstractSettings() {
            settingsManager = new SettingsManager<TS>(fileName);
            if (settingsManager.Settings == null) {
                settingsManager.Save(defaultSettings);
            }
            _settings = settingsManager.Settings;
        }

        public void Save() {
            settingsManager.Save();
        }
    }
}
