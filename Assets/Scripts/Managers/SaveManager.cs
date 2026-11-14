using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Office.SaveSystem;
using Office.SaveSystem.Data;

namespace Office.Managers
{
    [UsedImplicitly]
    public class SaveManager
    {
        private readonly SaveDataFactory _saveDataFactory;

        public SaveManager(SaveDataFactory saveDataFactory) =>
            _saveDataFactory = saveDataFactory;

        public async UniTask AutoSave() =>
            await SaveUtils.AutoSave(_saveDataFactory.GetSaveData());
        
        public async UniTask Save() =>
            await SaveUtils.Save(_saveDataFactory.GetSaveData());

        public async UniTask LoadLast()
        {
            var saveData = await SaveUtils.GetLastSave();
            await SaveUtils.Load(saveData);
        }

        public async UniTask Load(SaveData saveData) =>
            await SaveUtils.Load(saveData);
    }
}