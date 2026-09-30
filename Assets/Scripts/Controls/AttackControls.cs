using Office.Managers;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace Office.Controls
{
    [AddComponentMenu("Office/Controls/Attack Controls")]
    public class AttackControls : MonoBehaviour
    {
        [Inject] private InputManager _inputManager;
        [Inject] private EquipmentManager _equipmentManager;

        private void OnEnable() => _inputManager.InputSystem.Player.Attack.performed += Attack;

        private void OnDisable() => _inputManager.InputSystem.Player.Attack.performed -= Attack;

        private void Attack(InputAction.CallbackContext callbackContext)
            => _equipmentManager.CurrentWeapon.Attack();
    }
}