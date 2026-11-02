using System;
using DG.Tweening;
using Office.Weapons.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Office.Weapons
{
    [AddComponentMenu("Office/Weapons/Weapon Attack Animation")]
    public class AttackAnimationController : MonoBehaviour
    {
        [SerializeField] private AbstractWeaponAnimation[] _swingDownAnimations;
        [SerializeField] private AbstractWeaponAnimation[] _swingUpAnimations;

        private Tween _current;

        public Tween AnimateRandomly(WeaponObjectTransform weaponObjectTransform,
            Transform target, float duration, Action onImpact = null)
        {
            var targetOffset = target.position -
                               weaponObjectTransform.ParentObject.position;

            _current?.Kill();

            float durationPerAnim = duration / 2f;

            int downIndex = Random.Range(0, _swingDownAnimations.Length);
            int upIndex = Random.Range(0, _swingUpAnimations.Length);
            var downAnim = _swingDownAnimations[downIndex];
            var upAnim = _swingUpAnimations[upIndex];

            return _current = DOTween.Sequence()
                .Append(downAnim.PlayAnimation(weaponObjectTransform, target, durationPerAnim))
                .AppendCallback(() => onImpact?.Invoke())
                .Append(upAnim.PlayAnimationWithTargetOffset(weaponObjectTransform,
                    target, durationPerAnim, targetOffset))
                .SetLink(gameObject);
        }
    }
}