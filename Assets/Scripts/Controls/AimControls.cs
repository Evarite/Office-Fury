using Office.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Office.Controls
{
    public class AimControls : MonoBehaviour
    {
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _minZ;
        [SerializeField] private float _maxZ;

        private void OnEnable()
        {
            GameManager.Instance.InputSystem.Player.Aim.performed += Aim;
            GameManager.Instance.InputSystem.Player.Aim.canceled += Aim;
        }

        private void OnDisable()
        {
            GameManager.Instance.InputSystem.Player.Aim.performed -= Aim;
            GameManager.Instance.InputSystem.Player.Aim.canceled -= Aim;
        }

        private void Aim(InputAction.CallbackContext callbackContext)
        {
            Vector3 delta = callbackContext.ReadValue<Vector2>();

            Vector3 estimatedPos = GameManager.Instance.CurrentWeapon.transform.position + delta;

            float x = Mathf.Clamp(estimatedPos.x, _minX, _maxX);
            float z = Mathf.Clamp(estimatedPos.z, _minZ, _maxZ);

            Vector3 clampedPos = new Vector3(x, estimatedPos.y, z);

            GameManager.Instance.CurrentWeapon.transform.position = clampedPos;
        }
    }
}
