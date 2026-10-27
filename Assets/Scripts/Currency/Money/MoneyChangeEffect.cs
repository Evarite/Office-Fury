using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VContainer;

namespace Office.Currency.Money
{
    public class MoneyChangeEffect : MonoBehaviour
    {
        //TODO Possibly move to object pooling.
        //Overall, Idk if I need this but I'll let it be here for a while.

        [Header("Text Effect")]
        [SerializeField] private GameObject _textObjectPrefab;

        [Header("Text Effect Spawn Zone")]
        [SerializeField] private GameObject _moneyCounterUI;
        [SerializeField] private float _minXDif;
        [SerializeField] private float _maxXDif;
        [SerializeField] private float _minYDif;
        [SerializeField] private float _maxYDif;

        [Header("Text Color")]
        [SerializeField] private Color _positiveChangeColor;
        [SerializeField] private Color _negativeChangeColor;

        [Header("Effect Animation")]
        [SerializeField] private float _glideUpSpeed;

        [Header("Lifetime")]
        [SerializeField] private float _effectLifetime;

        [Inject] private MoneyCounter _moneyCounter;

        private List<TextMeshProUGUI> _textObjects = new();

        private float _alphaPerSecond;

        private void Awake() => _alphaPerSecond = 1f / _effectLifetime;

        private void OnEnable() => _moneyCounter.OnValueChanged += OnValueChanged;

        private void OnDisable() => _moneyCounter.OnValueChanged -= OnValueChanged;

        private void OnValueChanged(int newValue, int difference)
        {
            var text = Instantiate(_textObjectPrefab, _moneyCounterUI.transform, false)
                .GetComponent<TextMeshProUGUI>();

            text.text = difference.ToString("+0;-0;0");

            text.color = difference > 0 ? _positiveChangeColor : _negativeChangeColor;

            float x = Random.Range(_minXDif, _maxXDif);
            float y = Random.Range(_minYDif, _maxYDif);

            Vector3 dif = new Vector3(x, y, 0);

            text.transform.position += dif;

            _textObjects.Add(text);
        }

        private void Update()
        {
            for (int i = _textObjects.Count - 1; i >= 0; i--)
            {
                _textObjects[i].alpha -= _alphaPerSecond * Time.deltaTime;

                if (_textObjects[i].alpha <= 0)
                {
                    Destroy(_textObjects[i].gameObject);
                    _textObjects.RemoveAt(i);

                    continue;
                }

                _textObjects[i].transform.position += Vector3.up * _glideUpSpeed * Time.deltaTime;
            }
        }
    }
}