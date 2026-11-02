using DG.Tweening;
using UnityEngine;

namespace Office.Weapons.Animations
{
    public abstract class AbstractWeaponAnimation : ScriptableObject
    {
        [SerializeField] protected Ease ease;

        public abstract Tween PlayAnimation(WeaponObjectTransform weaponObjectTransform,
            Transform target, float duration);

        public abstract Tween PlayAnimationWithTargetOffset(
            WeaponObjectTransform weaponObjectTransform, Transform target, float duration,
            Vector3 targetOffset);
    }
}