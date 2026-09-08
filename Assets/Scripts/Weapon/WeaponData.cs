using UnityEngine;

namespace Office.Weapon
{
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _cooldown;
        [SerializeField] private float _staminaCost;

        public float Damage => _damage;
        public float Cooldown => _cooldown;
        public float StaminaCost => _staminaCost;
    }
}