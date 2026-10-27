using System.Collections;
using UnityEngine;

namespace Office.Weapons
{
    [AddComponentMenu("Office/Weapons/Weapon Attack")]
    public class WeaponAttack : MonoBehaviour
    {
        private Coroutine _attack = null;

        public void Attack(WeaponData data, AttackAnimationController animation) =>
            _attack ??= StartCoroutine(AttackDuration(data, animation));

        //TODO cache the WFSs
        private IEnumerator AttackDuration(WeaponData data, AttackAnimationController animation)
        {
            animation.AnimateRandomly(data.Duration);
            yield return new WaitForSeconds(data.Duration);

            Hit();

            yield return new WaitForSeconds(data.Cooldown);

            _attack = null;
        }

        //TODO add raycast check under the hammer for IHittable and deal damage
        private void Hit()
        {

        }
    }
}