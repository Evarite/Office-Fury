using System.Collections;
using UnityEngine;

namespace Office.Weapons
{
    [RequireComponent(typeof(Animator))]
    public class WeaponAttackAnimation : MonoBehaviour
    {
        [SerializeField] private float _animationStateResetDelay = 0.1f;

        private Animator _animator;

        private WaitForSeconds _stateReset;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _stateReset = new WaitForSeconds(_animationStateResetDelay);
        }

        private IEnumerator AttackDuration()
        {
            _animator.SetBool("Attack", true);

            yield return _stateReset;

            _animator.SetBool("Attack", false);
        }

        public void Attack() => StartCoroutine(AttackDuration());
    }
}
