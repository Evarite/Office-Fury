using System;
using UnityEngine;

namespace Office.HealthSystem
{
    /// <summary>
    /// Health is a class that manages health of an entity.
    /// </summary>
    [AddComponentMenu("Office/Health/Health")]
    public class Health : MonoBehaviour
    {
        [Tooltip("Max HP Value.")]
        [Min(1f)]
        [SerializeField] private float _maxHealth = 100f;

        private float _health;

        public float MaxHP => _maxHealth;
        public float HP => _health;

        /// <summary>
        /// Invoked once the entity takes damage.
        /// </summary>
        public event Action<float> OnDamage;

        /// <summary>
        /// Invoked once the entity dies.
        /// </summary>
        public event Action OnDeath;

        private void Awake() => _health = _maxHealth;

        /// <summary>
        /// Deals damage to the entity.
        /// </summary>
        /// <param name="damage">Amount of damage.</param>
        public void TakeDamage(float damage)
        {
            _health -= damage;
            OnDamage?.Invoke(damage);

            if (_health <= 0f)
                OnDeath?.Invoke();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            //IDeathHandler must be attached.
            if (GetComponent<IDeathHandler>() == null)
                Debug.LogError($"[{name}]: Missing IDeathHandler!");
        }
#endif
    }
}