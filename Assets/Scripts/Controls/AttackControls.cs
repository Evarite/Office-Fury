using Office.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Office.Controls
{
    public class AttackControls : MonoBehaviour
    {
        private void OnEnable() => GameManager.Instance.InputSystem.Player.Attack.performed += Attack;

        private void OnDisable() => GameManager.Instance.InputSystem.Player.Attack.performed -= Attack;

        private void Attack(InputAction.CallbackContext callbackContext)
            => GameManager.Instance.CurrentWeapon.Attack();
    }
}