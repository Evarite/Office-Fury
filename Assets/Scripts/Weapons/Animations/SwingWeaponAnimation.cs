using DG.Tweening;
using UnityEngine;

namespace Office.Weapons.Animations
{
    [CreateAssetMenu(fileName = "SwingAnimation", menuName = "Office/Weapons/Animations/Swing")]
    public class SwingWeaponAnimation : AbstractWeaponAnimation
    {
        [SerializeField] private Vector3 _finalRotation;

        public override Tween PlayAnimation(WeaponObjectTransform weaponObjectTransform,
            Transform target, float duration)
        {
            var start = weaponObjectTransform.ParentObject.position;

            var move = DOVirtual.Float(0f, 1f, duration, t =>
            {
                var offset = weaponObjectTransform.StrikingPoint.position -
                             weaponObjectTransform.ParentObject.position;
                var parentDest = target.position - offset;

                weaponObjectTransform.ParentObject.position = Vector3.Lerp(start,
                    parentDest, t);
            }).SetEase(ease);

            var rotate =
                weaponObjectTransform.PivotPoint.DORotate(_finalRotation, duration)
                    .SetEase(ease);

            return DOTween.Sequence()
                .Append(rotate)
                .Join(move);
        }

        public override Tween PlayAnimationWithTargetOffset(
            WeaponObjectTransform weaponObjectTransform, Transform target, float duration,
            Vector3 targetOffset)
        {
            var start = weaponObjectTransform.ParentObject.position;

            var move = DOVirtual.Float(0f, 1f, duration, t =>
            {
                var offset = weaponObjectTransform.StrikingPoint.position -
                             weaponObjectTransform.ParentObject.position;
                var parentDest = target.position - targetOffset;

                weaponObjectTransform.ParentObject.position = Vector3.Lerp(start,
                    parentDest, t);
            }).SetEase(ease);

            var rotate =
                weaponObjectTransform.PivotPoint.DORotate(_finalRotation, duration)
                    .SetEase(ease);

            return DOTween.Sequence()
                .Append(rotate)
                .Join(move);
        }
    }
}