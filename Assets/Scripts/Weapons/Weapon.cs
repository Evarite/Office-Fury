using UnityEngine;

namespace Office.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;

        public WeaponData WeaponData { get => _weaponData; set => _weaponData = value; }
    }
}