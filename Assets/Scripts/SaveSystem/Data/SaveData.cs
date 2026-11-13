namespace Office.SaveSystem.Data
{
    [System.Serializable]
    public class SaveData
    {
        private int _moneyCount;

        public SaveData(int moneyCount)
        {
            _moneyCount = moneyCount;
        }
    }
}