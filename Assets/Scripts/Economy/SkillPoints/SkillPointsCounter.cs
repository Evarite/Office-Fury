using System;
using JetBrains.Annotations;

namespace Office.Economy.SkillPoints
{
    [UsedImplicitly]
    public class SkillPointsCounter
    {
        private int _count;

        public int Count
        {
            get => _count;
            set
            {
                _count = value; 
                OnValueChanged?.Invoke(_count);
            }
        }

        public event Action<int> OnValueChanged;
    }
}