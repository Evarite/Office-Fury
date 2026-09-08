using System;
using UnityEngine;

namespace Office.Objects
{
    public class Health : MonoBehaviour
    {
        [Min(1f)]
        [SerializeField] private float _health = 100f;
        public float HP => _health;

        public event Action<float> OnDamage;
        public event Action OnDeath;

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