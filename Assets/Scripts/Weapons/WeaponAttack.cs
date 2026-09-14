using System.Collections;
using UnityEngine;

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

                //Raycast and deal damages

                //Attack reset animation
                yield return new WaitForSeconds(_weaponData.AttackResetAnimation.length);

                yield return new WaitForSeconds(_weaponData.Cooldown);
            }
        }
    }
}