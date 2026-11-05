using DG.Tweening;
using UnityEngine;

namespace Office.Weapons.Animations
{
    public abstract class AbstractWeaponAnimation : ScriptableObject
    {
        public abstract Tween PlayAnimation(WeaponObjectTransform weaponObjectTransform,
            Transform target, float duration, Ease ease);

        public abstract Tween PlayAnimationWithTargetOffset(
            WeaponObjectTransform weaponObjectTransform, Transform target, float duration,
            Ease ease, Vector3 targetOffset);
    }
}