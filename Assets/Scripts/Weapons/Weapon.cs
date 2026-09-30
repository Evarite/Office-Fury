using Office.Managers;
using UnityEngine;

namespace Office.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;

        [SerializeField] private WeaponAttack _weaponAttack;

        public WeaponData WeaponData => _weaponData;

        private void OnEnable() => GameManager.Instance.RegisterWeapon(this);

        public void Attack() => _weaponAttack.Attack();
    }
}