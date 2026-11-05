using System;
using Office.AimIndicator;
using UnityEngine;

namespace Office.Weapons
{
    /// <summary>
    ///     Basic weapon stats.
    /// </summary>
    [Serializable]
    public class WeaponData
    {
        [Header("Transform")]
        [Tooltip("Specifies the object transform hierarchy for animating.")]
        [SerializeField] private WeaponObjectTransform _objectTransform;

        [Header("Damage")]
        [Tooltip("How much damage is dealt per hit.")]
        [Min(1f)]
        [SerializeField] private float _damage = 25f;

        [Header("Stamina")]
        [Tooltip("How much stamina reduces per hit.")]
        [Min(0f)]
        [SerializeField] private float _staminaCost = 10f;

        [Header("Time")]
        [Tooltip("Amount of time in seconds between attacks.")]
        [Min(0f)]
        [SerializeField] private float _cooldown = 1f;
        [Tooltip("The time required for the animation to be fully completed.")]
        [Min(0f)]
        [SerializeField] private float _duration = 1f;

        [Header("Visuals")]
        [Tooltip("The target distance between the weapon and aim indicator.")]
        [SerializeField] private Vector3 _aimOffset = new(0, 1f, -1.5f);

        [Header("Aim Indicator")]
        [Tooltip("Decides how the aim indicator looks like for this weapon.")]
        [SerializeField] private AimIndicatorData _aimIndicatorData;

        public WeaponObjectTransform WeaponObjectTransform => _objectTransform;
        public float Damage => _damage;
        public float Cooldown => _cooldown;
        public float StaminaCost => _staminaCost;
        public float Duration => _duration;
        public Vector3 AimOffset => _aimOffset;
        public AimIndicatorData AimIndicatorData => _aimIndicatorData;
    }
}