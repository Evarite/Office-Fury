using System;
using System.IO;
using System.Linq;
using Cysharp.Threading.Tasks;
using Office.SaveSystem.Data;
using UnityEngine;

namespace Office.SaveSystem
{
    public static class SaveUtils
    {
        private static readonly string s_savePath =
            Path.Combine(Application.persistentDataPath, "saves");

        private static readonly string s_autoSavePath =
            Path.Combine(s_savePath, "autosave");

        public static async UniTask AutoSave(SaveData saveData)
        {
            string json = JsonUtility.ToJson(saveData);

            await File.WriteAllTextAsync(s_autoSavePath, json);
        }

        public static async UniTask Save(SaveData saveData)
        {
            string json = JsonUtility.ToJson(saveData);

            string saveTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string manualSavePath = Path.Combine(s_savePath, $"save_{saveTime}");

            await File.WriteAllTextAsync(manualSavePath, json);
        }

        public static async UniTask<SaveData> GetLastSave()
        {
            string latest = Directory.GetFiles(s_savePath, "*.json")
                .OrderByDescending(File.GetLastWriteTimeUtc)
                .FirstOrDefault();

            if (latest == null)
                return null;

            string json = await File.ReadAllTextAsync(latest);
            return JsonUtility.FromJson<SaveData>(json);
        }

        public static async UniTask<SaveData> GetSaveData(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            string json = await File.ReadAllTextAsync(filePath);
            return JsonUtility.FromJson<SaveData>(json);
        }

        //TODO
        public static async UniTask Load(SaveData saveData)
        {
        }
    }
}