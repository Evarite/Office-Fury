using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Office.Weapons
{
    [RequireComponent(typeof(Animator))]
    public class WeaponAttack : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;
        private Animator _animator;

        private void Awake() => _animator = GetComponent<Animator>();

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator AttackDuration()
        {
            while (true)
            {
                _animator.SetBool("Attack", true);
                yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
                _animator.SetBool("Attack", false);

                MouseRaycastAttack();

                yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);

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

        public void Attack() => StartCoroutine(AttackDuration());
    }
}