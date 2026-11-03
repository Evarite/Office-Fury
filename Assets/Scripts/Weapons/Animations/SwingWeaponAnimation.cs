using DG.Tweening;
using UnityEngine;

namespace Office.Weapons.Animations
{
    [CreateAssetMenu(fileName = "SwingAnimation", menuName = "Office/Weapons/Animations/Swing")]
    public class SwingWeaponAnimation : AbstractWeaponAnimation
    {
        [SerializeField] private Vector3 _finalRotation;

        public override Tween PlayAnimation(WeaponObjectTransform weaponObjectTransform,
            Transform target, float duration, Ease ease)
        {
            Vector3 start = default;
            bool isStarted = false;

            var move = DOVirtual.Float(0f, 1f, duration, t =>
            {
                if (!isStarted)
                {
                    start = weaponObjectTransform.ParentObject.position;
                    isStarted = true;
                }

                var offset = weaponObjectTransform.ParentObject.position -
                             weaponObjectTransform.StrikingPoint.position;
                var parentDest = target.position + offset;

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
            Ease ease, Vector3 targetOffset)
        {
            Vector3 start = default;
            bool isStarted = false;

            var move = DOVirtual.Float(0f, 1f, duration, t =>
            {
                if (!isStarted)
                {
                    start = weaponObjectTransform.ParentObject.position;
                    isStarted = true;
                }

                var parentDest = target.position + targetOffset;

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