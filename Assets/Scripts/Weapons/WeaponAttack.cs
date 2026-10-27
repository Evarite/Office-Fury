using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

namespace Office.Weapons
{
    [AddComponentMenu("Office/Weapons/Weapon Attack")]
    public class WeaponAttack : MonoBehaviour
    {
        private Task _attack = null;

        public async void TryAttack(WeaponData data, AttackAnimationController animController)
        {
            if (_attack != null && !_attack.IsCompleted)
                return;

            _attack = Attack(data, animController);
            await _attack;
        }

        private async Task Attack(WeaponData data, AttackAnimationController animController) =>
            await animController.AnimateRandomly(data.Duration, Hit).AsyncWaitForCompletion();

        //TODO add raycast check under the hammer for IHittable and deal damage
        private void Hit()
        {

        }
    }
}