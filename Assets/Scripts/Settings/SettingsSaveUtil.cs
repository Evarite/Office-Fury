using Office.Managers;
using UnityEngine;
using VContainer;
using System.IO;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Office.Settings
{
    /// <summary>
    /// Save system for Settings. Works separately from SaveSystem.
    /// </summary>
    public class SettingsSaveUtil : IStartable
    {
        [Inject] private SettingsManager _settingsManager;

        private const string SaveName = "settings.json";
        private readonly string _savePath = Path.Combine(Application.persistentDataPath,
            SaveName);

        public void Start() => _ = Load();

        //Saves when Apply button is pressed.
        public async UniTaskVoid Save()
        {
            var settings = _settingsManager.Settings;

            if (!settings.IsDirty)
                return;
            
            string json = JsonUtility.ToJson(settings);
            await File.WriteAllTextAsync(_savePath, json);

            settings.IsDirty = false;
        }

        public async UniTaskVoid CancelChanges()
        {
            if (!_settingsManager.Settings.IsDirty)
                return;

            await Load();
        }

        public void Reset()
        {
            GameSettings settings = new();
            
            _settingsManager.Load(settings);
        }
        
        private async UniTask Load()
        {
            GameSettings settings = new();

            try
            {
                string json = await File.ReadAllTextAsync(_savePath);
                settings = JsonUtility.FromJson<GameSettings>(json);
            }
            catch (FileNotFoundException e)
            {
            }
            finally
            {
                _settingsManager.Load(settings);
            }
        }
    }
}