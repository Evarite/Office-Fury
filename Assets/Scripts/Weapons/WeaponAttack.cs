using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Office.Weapons
{
    public class WeaponAttack : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;

        private void OnEnable() => StartCoroutine(Attack());

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator Attack()
        {
            while (true)
            {
                //Attack animation
                yield return new WaitForSeconds(_weaponData.AttackAnimation.length);

                MouseRaycastAttack();

                //Attack reset animation
                yield return new WaitForSeconds(_weaponData.AttackResetAnimation.length);

                yield return new WaitForSeconds(_weaponData.Cooldown);
            }
        }

        private void MouseRaycastAttack()
        {
            Vector2 screenPoint = Mouse.current.position.ReadValue();

            Ray ray = Camera.main.ScreenPointToRay(screenPoint);

            //Perhaps switch to RaycastAll
            if (Physics.Raycast(ray, out RaycastHit hit))
                if (hit.collider.TryGetComponent<IHittable>(out var hittable))
                    hittable.Hit(_weaponData.Damage);
        }
    }
}