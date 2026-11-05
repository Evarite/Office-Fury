using System;
using JetBrains.Annotations;
using Office.Weapons;

namespace Office.Managers
{
    [UsedImplicitly]
    public class EquipmentManager
    {
        private Weapon _currentWeapon = null;
        
        public event Action<WeaponData> OnWeaponChanged;
        
        public Weapon CurrentWeapon
        {
            get => _currentWeapon;
            set
            {
                _currentWeapon = value;
                
                OnWeaponChanged?.Invoke(_currentWeapon.WeaponData);
            }
        }
    }
}
