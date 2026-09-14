using UnityEngine;

namespace Office.Weapons
{
    /// <summary>
    /// Basic weapon stats.
    /// </summary>
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Office/Weapons/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [Tooltip("How much damage is dealt per hit.")]
        [Min(1f)]
        [SerializeField] private float _damage = 25f;
        [Tooltip("Amount of time in seconds between attacks.")]
        [Min(0f)]
        [SerializeField] private float _cooldown = 1f;
        [Tooltip("How much stamina reduces per hit.")]
        [Min(0f)]
        [SerializeField] private float _staminaCost = 10f;
        [Tooltip("Animation used to represent the attack.")]
        [SerializeField] private AnimationClip _attackAnimation;
        [Tooltip("Animation used to represent attack reset,].")]
        [SerializeField] private AnimationClip _attackResetAnimation;

        public float Damage => _damage;
        public float Cooldown => _cooldown;
        public float StaminaCost => _staminaCost;

        public AnimationClip AttackAnimation { get => _attackAnimation; set => _attackAnimation = value; }
        public AnimationClip AttackResetAnimation { get => _attackResetAnimation; set => _attackResetAnimation = value; }
    }
}