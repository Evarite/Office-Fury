using System;
using UnityEngine;

namespace Office.AimIndicator
{
    [Serializable]
    public class AimIndicatorData
    {
        [Header("Aim Style")]
        [SerializeField] private Material _material;

        [Header("Radii")]
        [SerializeField] private float _outerRadius = 0.5f;
        [SerializeField] private float _innerRadius = 0.45f;

        [Header("Color")]
        [SerializeField] private Color _color = Color.red;

        [Header("Dash")]
        [SerializeField] private int _dashCount = 10;
        [Range(0f, 1f)]
        [SerializeField] private float _dashFill = 0.5f;

        public Material Material => _material;

        public float OuterRadius { get => _outerRadius; set => _outerRadius = value; }

        public float InnerRadius { get => _innerRadius; set => _innerRadius = value; }

        public Color Color { get => _color; set => _color = value; }
        public int DashCount { get => _dashCount; set => _dashCount = value; }
        public float DashFill { get => _dashFill; set => _dashFill = value; }
    }
}