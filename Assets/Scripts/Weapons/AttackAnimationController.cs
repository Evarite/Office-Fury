using DG.Tweening;
using Office.Weapons.Animations;
using UnityEngine;

namespace Office.Weapons
{
    [AddComponentMenu("Office/Weapons/Weapon Attack Animation")]
    public class AttackAnimationController : MonoBehaviour
    {
        [SerializeField] private AbstractAnimation[] _swingDownAnimations;
        [SerializeField] private AbstractAnimation[] _swingUpAnimations;

        private Tween current;

        public Tween AnimateRandomly(float duration, System.Action onImpact = null)
        {
            current?.Kill();

            float durationPerAnim = duration / 2f;

            int downIndex = Random.Range(0, _swingDownAnimations.Length);
            int upIndex = Random.Range(0, _swingUpAnimations.Length);
            var downAnim = _swingDownAnimations[downIndex];
            var upAnim = _swingUpAnimations[upIndex];

            return current = DOTween.Sequence()
                .Append(downAnim.PlayAnimation(transform, durationPerAnim))
                .AppendCallback(() => onImpact?.Invoke())
                .Append(upAnim.PlayAnimation(transform, durationPerAnim))
                .SetLink(gameObject);
        }
    }
}