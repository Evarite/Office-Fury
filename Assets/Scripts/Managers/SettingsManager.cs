using JetBrains.Annotations;
using Office.Settings;

namespace Office.Managers
{
    [UsedImplicitly]
    public class SettingsManager
    {
        public GameSettings Settings { get; private set; } = new();

        public void Load(GameSettings settings) => Settings = settings;
    }
}