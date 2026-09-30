using Office.Managers;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace Office.Controls
{
    [AddComponentMenu("Office/Controls/Aim Controls")]
    public class AimControls : MonoBehaviour
    {
        [Header("Mouse Delta Ratio")]
        [SerializeField] private float _mouseDeltaRatio = 0.01f;

        [Header("Position Clamp")]
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _minZ;
        [SerializeField] private float _maxZ;

        [Inject] private InputManager _inputManager;
        [Inject] private EquipmentManager _equipmentManager;
        [Inject] private SettingsManager _settingsManager;

        private void OnEnable() => _inputManager.InputSystem.Player.Aim.performed += Aim;

        private void OnDisable() => _inputManager.InputSystem.Player.Aim.performed -= Aim;

        private void Aim(InputAction.CallbackContext callbackContext)
        {
            Transform weaponTransform = _equipmentManager.CurrentWeapon.transform;

            Vector3 delta = callbackContext.ReadValue<Vector2>() * _mouseDeltaRatio;

            Vector3 pos = weaponTransform.position + new Vector3(delta.x, 0, delta.y) *
                _settingsManager.Settings.MouseSensitivity;

            pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
            pos.z = Mathf.Clamp(pos.z, _minZ, _maxZ);

            weaponTransform.position = pos;
        }
    }
}
