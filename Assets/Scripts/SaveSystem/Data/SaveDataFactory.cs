using Office.Economy.Money;
using VContainer;

namespace Office.SaveSystem.Data
{
    public class SaveDataFactory
    {
        private readonly MoneyCounter _moneyCounter;

        [Inject]
        public SaveDataFactory(MoneyCounter moneyCounter)
        {
            _moneyCounter = moneyCounter;
        }

        public SaveData GetSaveData() => 
            new(_moneyCounter.Count);
    }
}