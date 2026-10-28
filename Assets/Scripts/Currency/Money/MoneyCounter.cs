using JetBrains.Annotations;

namespace Office.Currency.Money
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
                var oldValue = _count;
                _count = value;
                var dif = _count - oldValue;

                OnValueChanged?.Invoke(value, dif);
            }
        }

        public event MoneyUpdateHandler OnValueChanged;
    }
}