using Office.Managers;
using UnityEngine;
using VContainer;

namespace Office.Weapons
{
    [RequireComponent(typeof(WeaponAttack))]
    [RequireComponent(typeof(WeaponAttackAnimations))]
    [AddComponentMenu("Office/Weapons/Weapon")]
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;

        private WeaponAttack _weaponAttack;
        private WeaponAttackAnimations _weaponAttackAnimations;

        [Inject] private EquipmentManager _equipmentManager;

        public WeaponData WeaponData => _weaponData;

        private void Awake()
        {
            _weaponAttack = GetComponent<WeaponAttack>();
            _weaponAttackAnimations = GetComponent<WeaponAttackAnimations>();
        }

        private void OnEnable() => _equipmentManager.CurrentWeapon = this;

        public void Attack() => _weaponAttack.Attack(_weaponData, _weaponAttackAnimations);
    }
}