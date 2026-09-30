using Office.Managers;
using UnityEngine;
using VContainer;

namespace Office.Weapons
{
    [AddComponentMenu("Office/Weapons/Weapon")]
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;

        [SerializeField] private WeaponAttack _weaponAttack;

        [Inject] private EquipmentManager _equipmentManager;

        public WeaponData WeaponData => _weaponData;

        private void OnEnable() => _equipmentManager.CurrentWeapon = this;

        public void Attack() => _weaponAttack.Attack();
    }
}