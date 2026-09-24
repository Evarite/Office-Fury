using Office.Managers;
using UnityEngine;

namespace Office.Weapons
{
    [RequireComponent(typeof(WeaponAttack))]
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;

        private WeaponAttack _weaponAttack;

        public WeaponData WeaponData => _weaponData;

        private void Awake() => _weaponAttack = GetComponent<WeaponAttack>();

        private void OnEnable() => GameManager.Instance.RegisterWeapon(this);

        public void Attack() => _weaponAttack.Attack();
    }
}