namespace Office.Currency.Money
{
    public class MoneyCounter
    {
        private int _count = 0;

        public delegate void MoneyUpdateHandler(int newValue, int difference);

        public event MoneyUpdateHandler OnValueChanged;

        public int Count
        {
            get => _count;
            set
            {
                int oldValue = _count;
                _count = value;
                int dif = _count - oldValue;

                OnValueChanged?.Invoke(value, dif);
            }
        }
    }
}
