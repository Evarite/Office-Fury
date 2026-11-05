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
        [SerializeField] private LayerMask _objectsLayer;
        [SerializeField] private int _maxCollisions = 5;
        
        [Inject] private AimManager _aimManager;

        private CancellationToken _destroyToken;

        private bool _isCooldown;

        private Collider[] _colliders;

        //TODO Maybe rework _weaponFollow and move it elsewhere

        [Inject] private WeaponFollow _weaponFollow;

        private void Awake()
        {
            _destroyToken = this.GetCancellationTokenOnDestroy();
            _colliders = new Collider[_maxCollisions];
        }

        public async UniTaskVoid TryAttack(WeaponData data,
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
                _weaponFollow.enabled = true;
                _isCooldown = false;
            }
        }

        private async UniTask Attack(WeaponData data,
            AttackAnimationController animController) =>
            await animController.AnimateRandomly(data.WeaponObjectTransform,
                    _aimManager.AimIndicatorTransform, data.Duration, () => Hit(data))
                .ToUniTask(cancellationToken: _destroyToken);
        
        private void Hit(WeaponData data)
        {
            int count = Physics.OverlapSphereNonAlloc(
                _aimManager.AimIndicatorTransform.position, _aimManager.SphereRadius,
                _colliders, _objectsLayer);

            for (int i = 0; i < count; i++)
            {
                if (_colliders[i].TryGetComponent<IHittable>(out var hittable))
                {
                    Debug.Log($"Hit: {data.Damage} damage.");
                }
            }
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