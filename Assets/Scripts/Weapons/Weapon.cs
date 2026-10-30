using Office.Managers;
using UnityEngine;
using VContainer;

namespace Office.Weapons
{
    [RequireComponent(typeof(WeaponAttack))]
    [RequireComponent(typeof(AttackAnimationController))]
    [AddComponentMenu("Office/Weapons/Weapon")]
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;
        
        private WeaponAttack _weaponAttack;

        [Inject] private EquipmentManager _equipmentManager;
        private AttackAnimationController _weaponAttackAnimations;

        public WeaponData WeaponData => _weaponData;

        private void Awake()
        {
            _weaponAttack = GetComponent<WeaponAttack>();
            _weaponAttackAnimations = GetComponent<AttackAnimationController>();
        }

        private void OnEnable() => _equipmentManager.CurrentWeapon = this;

        public void Attack() => _weaponAttack.TryAttack(_weaponData, _weaponAttackAnimations);
    }
}