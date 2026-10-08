using Office.HealthSystem;
using UnityEngine;

namespace Office.Objects
{
    /// <summary>
    /// Basic DeathHandler of an object. Invoked by Health on the object's death.
    /// </summary>
    [AddComponentMenu("Office/Objects/Object Death Handler")]
    [RequireComponent(typeof(Health))]
    public class ObjectDeathHandler : MonoBehaviour, IDeathHandler
    {
        protected Health _health;

        protected virtual void Awake() => _health = GetComponent<Health>();

        private void OnEnable() => _health.OnDeath += Die;

        private void OnDisable() => _health.OnDeath -= Die;

        public virtual void Die() => Destroy(gameObject);
    }
}