using System.Collections.Generic;
using Office.Economy.Money;
using Office.Pooling;
using TMPro;
using UnityEngine;
using VContainer;

namespace Office.Economy.Money
{
    [AddComponentMenu("Office/Money/MoneyChangeEffect")]
    public class MoneyChangeEffect : MonoBehaviour
    {
        //TODO Possibly move to object pooling.
        //TODO Rework this to use pooling properly
        //Overall, Idk if I need this but I'll let it be here for a while.

        [SerializeField] private EffectSpawnData _spawnData;

        [Inject] private MoneyCounter _moneyCounter;
        [Inject] private PoolService _poolService;

        private readonly List<TextMeshProUGUI> _textObjects = new();

        private float _alphaPerSecond;

        private void Awake() => _alphaPerSecond = 1f / _spawnData.EffectLifetime;

        private void OnEnable() => _moneyCounter.OnValueChanged += OnValueChanged;

        private void OnDisable() => _moneyCounter.OnValueChanged -= OnValueChanged;

        private void OnValueChanged(int newValue, int difference)
        {
            _poolService.TryGet(_spawnData.TextObjectPrefab, out var entity);
            entity.transform.position = _spawnData.CounterUI.transform.position;
            
            var text = entity.GetComponent<TextMeshProUGUI>();

            text.text = difference.ToString("+0;-0;0");

            text.color = difference > 0 ? _spawnData.PositiveChangeColor :
                _spawnData.NegativeChangeColor;

            var x = Random.Range(_spawnData.MinXDif, _spawnData.MaxXDif);
            var y = Random.Range(_spawnData.MinYDif, _spawnData.MaxYDif);

            var dif = new Vector3(x, y, 0);

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

                _textObjects[i].transform.position += 
                    Vector3.up * (_spawnData.GlideUpSpeed * Time.deltaTime);
            }
        }
    }
}