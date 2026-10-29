using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Office.Weapons
{
    [AddComponentMenu("Office/Weapons/Weapon Attack")]
    public class WeaponAttack : MonoBehaviour
    {
        private bool _isCooldown;

        public async void TryAttack(WeaponData data, AttackAnimationController animController)
        {
            try
            {
                if (_isCooldown)
                    return;

                _isCooldown = true;
                await Attack(data, animController);

                await UniTask.Delay(TimeSpan.FromSeconds(data.Duration));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
                _isCooldown = false;
            }
        }

        private async UniTask Attack(WeaponData data, AttackAnimationController animController) =>
            await animController.AnimateRandomly(data.Duration, Hit).ToUniTask();

        //TODO add raycast check under the hammer for IHittable and deal damage
        private void Hit()
        {
        }
    }
}