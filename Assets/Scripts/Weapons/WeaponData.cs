using System;
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
        [Tooltip("Specifies ")]
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

        public WeaponObjectTransform WeaponObjectTransform => _objectTransform;
        public float Damage => _damage;
        public float Cooldown => _cooldown;
        public float StaminaCost => _staminaCost;
        public float Duration => _duration;
    }
}