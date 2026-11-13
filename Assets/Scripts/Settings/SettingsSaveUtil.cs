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
            string json = JsonUtility.ToJson(_settingsManager.Settings);
            await File.WriteAllTextAsync(_savePath, json);
        }

        private async UniTaskVoid Load()
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