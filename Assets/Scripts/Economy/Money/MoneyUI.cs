using TMPro;
using UnityEngine;
using VContainer;

namespace Office.Economy.Money
{
    [AddComponentMenu("Office/UI/Money/Money UI")]
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _displayText;

        [Inject] private MoneyCounter _counter;

        private void OnEnable() => _counter.OnValueChanged += UpdateUI;

        private void OnDisable() => _counter.OnValueChanged -= UpdateUI;

        private void UpdateUI(int value, int difference) =>
            _displayText.text = value.ToString();
    }
}