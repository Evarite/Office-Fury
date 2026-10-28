using System.Collections.Generic;
using Office.Pooling;
using TMPro;
using UnityEngine;
using VContainer;

namespace Office.Economy.Money
{
    [AddComponentMenu("Office/UI/Money/MoneyChangeEffect UI")]
    public class MoneyChangeEffectUI : MonoBehaviour
    {
        //TODO Possibly move to object pooling.
        //TODO Rework this to use pooling properly
        //Overall, Idk if I need this but I'll let it be here for a while.

        [SerializeField] private EffectSpawnData _spawnData;
        private readonly List<PooledEntity> _entitiesToRemove = new();

        private readonly Dictionary<PooledEntity, TextObject> _textObjects = new();

        private float _alphaPerSecond;

        [Inject] private MoneyCounter _moneyCounter;
        [Inject] private PoolService _poolService;

        private void Awake() => _alphaPerSecond = 1f / _spawnData.EffectLifetime;

        private void OnEnable() => _moneyCounter.OnValueChanged += OnValueChanged;

        private void OnDisable() => _moneyCounter.OnValueChanged -= OnValueChanged;

        private void Update()
        {
            foreach (var obj in _textObjects)
            {
                obj.Value.Text.alpha -= _alphaPerSecond * Time.deltaTime;

                if (obj.Value.Text.alpha <= 0)
                {
                    _entitiesToRemove.Add(obj.Key);
                    continue;
                }

                obj.Value.Transform.anchoredPosition +=
                    obj.Value.Direction * (_spawnData.GlideUpSpeed * Time.deltaTime);
            }

            foreach (var entity in _entitiesToRemove)
            {
                entity.Return();
                _textObjects.Remove(entity);
            }

            _entitiesToRemove.Clear();
        }

        private void OnValueChanged(int newValue, int difference)
        {
            _poolService.TryGet(_spawnData.TextObjectPrefab, _spawnData.Parent, out var entity);
            var rectTransform = entity.transform as RectTransform;

            if (rectTransform == null)
            {
                Debug.LogError($"{entity.name}: Object doesn't have RectTransform!");
                return;
            }

            rectTransform.anchoredPosition = _spawnData.CounterUI.anchoredPosition;

            var text = entity.GetComponent<TextMeshProUGUI>();

            text.text = difference.ToString("+0;-0;0");

            float x = Random.Range(_spawnData.MinXDif, _spawnData.MaxXDif);
            float y = Random.Range(_spawnData.MinYDif, _spawnData.MaxYDif);

            var dif = new Vector2(x, y);

            rectTransform.anchoredPosition += dif;

            Vector2 direction;

            if (difference > 0)
            {
                text.color = _spawnData.PositiveChangeColor;
                direction = Vector2.up;
            }
            else
            {
                text.color = _spawnData.NegativeChangeColor;
                direction = Vector2.down;

                rectTransform.anchoredPosition +=
                    Vector2.up * (_spawnData.GlideUpSpeed * _spawnData.EffectLifetime);
            }

            _textObjects.Add(entity, new TextObject(text, rectTransform, direction));
        }

        private class TextObject
        {
            public TextObject(TextMeshProUGUI text, RectTransform rectTransform, Vector2 direction)
            {
                Text = text;
                Transform = rectTransform;
                Direction = direction;
            }

            public TextMeshProUGUI Text { get; }

            public RectTransform Transform { get; }

            public Vector2 Direction { get; }
        }
    }
}