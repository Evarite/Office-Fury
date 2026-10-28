using System;
using Office.Pooling;
using UnityEngine;

namespace Office.Economy.Money
{
    [Serializable]
    public class EffectSpawnData
    {
        [Header("Lifetime")] 
        [SerializeField] private float _effectLifetime;

        [Header("Effect Animation")] 
        [SerializeField] private float _glideUpSpeed;

        [SerializeField] private float _maxXDif;
        [SerializeField] private float _maxYDif;
        [SerializeField] private float _minXDif;
        [SerializeField] private float _minYDif;

        [Header("Text Effect Spawn Zone")] 
        [SerializeField] private GameObject _moneyCounterUI;

        [Header("Text Color")] 
        [SerializeField] private Color _positiveChangeColor;
        [SerializeField] private Color _negativeChangeColor;

        [Header("Text Effect")] 
        [SerializeField] private PooledEntity _textObjectPrefab;

        public float EffectLifetime => _effectLifetime;

        public float GlideUpSpeed => _glideUpSpeed;

        public float MaxXDif => _maxXDif;

        public float MaxYDif => _maxYDif;

        public float MinXDif => _minXDif;

        public float MinYDif => _minYDif;

        public GameObject CounterUI => _moneyCounterUI;

        public Color PositiveChangeColor => _positiveChangeColor;

        public Color NegativeChangeColor => _negativeChangeColor;

        public PooledEntity TextObjectPrefab => _textObjectPrefab;
    }
}