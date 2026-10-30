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
        [SerializeField] private Vector3 _targetDistance;

        [SerializeField] private float _smoothTime;
        [Inject] private AimManager _aimManager;
        private Vector3 _currentVelocity = Vector3.zero;

        [Inject] private EquipmentManager _equipmentManager;

        private Vector3 _targetPoint;

        private void LateUpdate()
        {
            _targetPoint = _aimManager.AimIndicatorTransform.position + _targetDistance;

            var weaponTransform = _equipmentManager.CurrentWeapon.transform;

            weaponTransform.position = Vector3.SmoothDamp(weaponTransform.position,
                _targetPoint, ref _currentVelocity, _smoothTime);
        }
    }
}