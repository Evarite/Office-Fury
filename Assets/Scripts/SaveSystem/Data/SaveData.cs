using UnityEngine;

namespace Office.SaveSystem.Data
{
    [System.Serializable]
    public class SaveData
    {
        [SerializeField] private int _money;

        public SaveData(int money)
        {
            _money = money;
        }
    }
}