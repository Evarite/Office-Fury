using System;
using DG.Tweening;
using Office.Weapons.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Office.Weapons
{
    [RequireComponent(typeof(Weapon))]
    [AddComponentMenu("Office/Weapons/Weapon Attack Animation")]
    public class AttackAnimationController : MonoBehaviour
    {
        [Header("Animations")]
        [SerializeField] private AbstractWeaponAnimation[] _swingDownAnimations;
        [SerializeField] private AbstractWeaponAnimation[] _swingUpAnimations;

        [Header("Easing")]
        [SerializeField] private Ease _easeIn;
        [SerializeField] private Ease _easeOut;

        private Tween _current;

        private Weapon _weapon;

        private void Awake() => _weapon = GetComponent<Weapon>();

        public Tween AnimateRandomly(WeaponObjectTransform weaponObjectTransform,
            Transform target, float duration, Action onImpact = null)
        {
            _current?.Kill();

            float durationPerAnim = duration / 2f;

            int downIndex = Random.Range(0, _swingDownAnimations.Length);
            int upIndex = Random.Range(0, _swingUpAnimations.Length);
            var downAnim = _swingDownAnimations[downIndex];
            var upAnim = _swingUpAnimations[upIndex];

            return _current = DOTween.Sequence()
                .Append(downAnim.PlayAnimation(weaponObjectTransform, target,
                    durationPerAnim, _easeIn))
                .AppendCallback(() => onImpact?.Invoke())
                .Append(upAnim.PlayAnimationWithTargetOffset(weaponObjectTransform,
                    target, durationPerAnim, _easeOut, _weapon.WeaponData.AimOffset))
                .SetLink(gameObject);
        }
    }
}