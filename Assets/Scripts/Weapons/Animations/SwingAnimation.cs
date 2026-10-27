using DG.Tweening;
using UnityEngine;

namespace Office.Weapons.Animations
{
    public class SwingAnimation : AbstractAnimation
    {
        [SerializeField] private float _rotationAngle = 90f;

        public override Tween PlayAnimation(Transform transform, float duration) =>
            DOTween.Sequence()
            .Append(transform.DORotate(new(_rotationAngle, 0f, 0f), duration))
            .SetEase(ease);
    }
}