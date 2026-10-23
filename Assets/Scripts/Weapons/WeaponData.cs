using UnityEngine;

namespace Office.Weapons
{
    /// <summary>
    /// Basic weapon stats.
    /// </summary>
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Office/Weapons/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
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
        [SerializeField] private float _animationDuration = 1f;

        public float Damage => _damage;
        public float Cooldown => _cooldown;
        public float StaminaCost => _staminaCost;
        public float AnimationDuration => _animationDuration;
    }
}