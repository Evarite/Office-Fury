using Office.Managers;
using UnityEngine;
using VContainer;

namespace Office.Weapons
{
    /// <summary>
    ///     This class is used to make the weapon follow the aim indicator.
    /// </summary>
    [AddComponentMenu("Office/Weapons/Weapon Follow")]
    public class WeaponFollow : MonoBehaviour
    {
        [Min(0f)]
        [Tooltip("Target smooth time value")]
        [SerializeField] private float _smoothTime = 0.2f;

        [Inject] private AimManager _aimManager;

        private Vector3 _currentVelocity = Vector3.zero;

        [Inject] private EquipmentManager _equipmentManager;

        private Vector3 _targetPoint;

        public Vector3 CurrentVelocity { set => _currentVelocity = value; }

        private void OnEnable() => _currentVelocity = Vector3.zero;

        private void LateUpdate()
        {
            var weapon = _equipmentManager.CurrentWeapon;

            _targetPoint = _aimManager.AimIndicatorTransform.position
                           + weapon.WeaponData.AimOffset;

            var weaponTransform = weapon.transform;

            weaponTransform.position = Vector3.SmoothDamp(weaponTransform.position,
                _targetPoint, ref _currentVelocity, _smoothTime);
        }
    }
}