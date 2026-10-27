using DG.Tweening;
using Office.Weapons.Animations;
using UnityEngine;

namespace Office.Weapons
{
    [AddComponentMenu("Office/Weapons/Weapon Attack Animation")]
    public class WeaponAttackAnimations : MonoBehaviour
    {
        [SerializeField] private AbstractAnimation[] _animations;

        private Tween current;

        public Tween AnimateRandomly(float duration)
        {
            current?.Kill();

            int index = Random.Range(0, _animations.Length);
            var animation = _animations[index];

            return current = _animations[index]
                .PlayAnimation(transform, duration)
                .SetLink(gameObject);
        }
    }
}