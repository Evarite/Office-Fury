using System;
using JetBrains.Annotations;
using Office.Managers;
using Office.Weapons;
using VContainer.Unity;

namespace Office.AimIndicator
{
    [UsedImplicitly]
    public class AimIndicatorSwitch : IStartable, IDisposable
    {
        private readonly AimIndicatorController _controller;
        private readonly EquipmentManager _equipmentManager;

        public AimIndicatorSwitch(AimIndicatorController controller,
            EquipmentManager equipmentManager)
        {
            _controller = controller;
            _equipmentManager = equipmentManager;
        }

        public void Start() => _equipmentManager.OnWeaponChanged += 
            OnNewWeaponRegistered;

        public void Dispose() => _equipmentManager.OnWeaponChanged -=
            OnNewWeaponRegistered;

        private void OnNewWeaponRegistered(WeaponData data) =>
            _controller.Apply(data.AimIndicatorData);
    }
}