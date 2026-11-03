using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Office.Managers;
using UnityEngine;
using VContainer;

namespace Office.Weapons
{
    [AddComponentMenu("Office/Weapons/Weapon Attack")]
    public class WeaponAttack : MonoBehaviour
    {
        [Inject] private AimManager _aimManager;

        private CancellationToken _destroyToken;

        private bool _isCooldown;

        //TODO Maybe rework _weaponFollow and move it elsewhere

        [Inject] private WeaponFollow _weaponFollow;

        private void Awake() => _destroyToken = this.GetCancellationTokenOnDestroy();

        public async void TryAttack(WeaponData data,
            AttackAnimationController animController)
        {
            try
            {
                if (_isCooldown)
                    return;

                _isCooldown = true;

                var attack = Attack(data, animController).Preserve();
                var calculateSpeed =
                    CalculateEndSpeed(data.WeaponObjectTransform.ParentObject,
                        attack, _destroyToken);

                _weaponFollow.enabled = false;

                await attack;
                var speed = await calculateSpeed;

                _weaponFollow.CurrentVelocity = speed;
                _weaponFollow.enabled = true;

                await UniTask.Delay(TimeSpan.FromSeconds(data.Cooldown),
                    cancellationToken: _destroyToken);
            }
            catch (OperationCanceledException)
            {
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

        private async UniTask Attack(WeaponData data,
            AttackAnimationController animController) =>
            await animController.AnimateRandomly(data.WeaponObjectTransform,
                _aimManager.AimIndicatorTransform, data.Duration, Hit)
                .ToUniTask(cancellationToken: _destroyToken);

        //TODO add raycast check under the hammer for IHittable and deal damage
        private void Hit()
        {
        }

        private static async UniTask<Vector3> CalculateEndSpeed(Transform tracked,
            UniTask attack, CancellationToken token)
        {
            var pos = tracked.position;

            Vector3 speed = default;

            while (attack.Status == UniTaskStatus.Pending)
            {
                await UniTask.Yield(PlayerLoopTiming.LastPreLateUpdate, token);

                var prev = pos;
                pos = tracked.position;

                speed = (pos - prev) / Mathf.Max(Time.deltaTime, 0.00001f);
            }

            return speed;
        }
    }
}