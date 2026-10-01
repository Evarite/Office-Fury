using Office.Settings;

namespace Office.Managers
{
    public class SettingsManager
    {
        public GameSettings Settings { get; private set; } = new GameSettings();
    }
}
