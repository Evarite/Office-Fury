using System.Collections;
using UnityEngine;

namespace Office.Weapons
{
    [RequireComponent(typeof(WeaponAttackAnimation))]
    public class WeaponAttack : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;

        private WeaponAttackAnimation _weaponAttackAnimation;

        private WaitForSeconds _attackCooldown;

        private void Awake()
        {
            _weaponAttackAnimation = GetComponent<WeaponAttackAnimation>();
            _attackCooldown = new WaitForSeconds(_weaponData.Cooldown);
        }

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator AttackDuration()
        {
            _weaponAttackAnimation.Attack();

            HitPointRaycast();

            yield return _attackCooldown;
        }

        private void HitPointRaycast()
        {
            //Replace zero with hammer hit pos
            Vector2 screenPoint = Vector2.zero;

            Ray ray = Camera.main.ScreenPointToRay(screenPoint);

            //Perhaps switch to RaycastAll
            if (Physics.Raycast(ray, out RaycastHit hit))
                if (hit.collider.TryGetComponent<IHittable>(out var hittable))
                    hittable.Hit(_weaponData.Damage);
        }

        public void Attack() => StartCoroutine(AttackDuration());
    }
}