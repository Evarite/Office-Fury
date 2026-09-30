using Office.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Office.Controls
{
    public class AimControls : MonoBehaviour
    {
        [Header("Mouse Delta Ratio")]
        [SerializeField] private float _mouseDeltaRatio = 0.01f;

        [Header("Position Clamp")]
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _minZ;
        [SerializeField] private float _maxZ;

        private void OnEnable() => GameManager.Instance.InputSystem.Player.Aim.performed += Aim;

        private void OnDisable() => GameManager.Instance.InputSystem.Player.Aim.performed -= Aim;

        private void Aim(InputAction.CallbackContext callbackContext)
        {
            Transform weaponTransform = GameManager.Instance.CurrentWeapon.transform;

            Vector3 delta = callbackContext.ReadValue<Vector2>() * _mouseDeltaRatio;

            Vector3 pos = weaponTransform.position + new Vector3(delta.x, 0, delta.y) *
                GameManager.Instance.SettingsManager.Settings.MouseSensitivity;

            pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
            pos.z = Mathf.Clamp(pos.z, _minZ, _maxZ);

            weaponTransform.position = pos;
        }
    }
}
