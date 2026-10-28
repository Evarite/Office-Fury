using System;
using JetBrains.Annotations;

namespace Office.Economy.Money
{
    [UsedImplicitly]
    public class MoneyCounter
    {
        public delegate void MoneyUpdateHandler(int newValue, int difference);

        private int _count;

        public int Count
        {
            get => _count;
            set
            {
                int oldValue = _count;
                _count = value;
                int dif = _count - oldValue;

                OnValueChanged?.Invoke(value, dif);

                if (_count < 0f)
                    OnNegativeBalance?.Invoke();
            }
        }

        public event MoneyUpdateHandler OnValueChanged;
        public event Action OnNegativeBalance;
    }
}