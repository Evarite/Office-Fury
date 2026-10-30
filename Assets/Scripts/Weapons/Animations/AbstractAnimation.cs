using DG.Tweening;
using UnityEngine;

namespace Office.Weapons.Animations
{
    public abstract class AbstractAnimation : ScriptableObject
    {
        [SerializeField] protected Ease ease;

        public abstract Tween PlayAnimation(WeaponObjectTransform weaponObjectTransform,
            float duration);
    }
}