using DG.Tweening;
using UnityEngine;

namespace Office.Weapons.Animations
{
    [CreateAssetMenu(fileName = "SwingAnimation", menuName = "Office/Weapons/Animations/Swing")]
    public class SwingAnimation : AbstractAnimation
    {
        [SerializeField] private Vector3 _finalRotation;

        public override Tween PlayAnimation(WeaponObjectTransform weaponObjectTransform,
            float duration) =>
            DOTween.Sequence()
            .Append(weaponObjectTransform.PivotPoint.DORotate(_finalRotation, duration))
            .SetEase(ease);
    }
}