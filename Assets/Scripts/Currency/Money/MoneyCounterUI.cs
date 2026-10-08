using TMPro;
using UnityEngine;
using VContainer;

namespace Office.Currency.Money
{
    public class MoneyCounterUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _displayText;

        [Inject] private MoneyCounter _counter;

        private void OnEnable() => _counter.OnValueChanged += UpdateUI;

        private void OnDisable() => _counter.OnValueChanged -= UpdateUI;

        private void UpdateUI(int value, int difference) => _displayText.text = value.ToString();
    }
}