using Office.HealthSystem;
using UnityEngine;

namespace Office.Objects
{
    /// <summary>
    ///     Basic DeathHandler of an object. Invoked by Health on the object's death.
    /// </summary>
    [AddComponentMenu("Office/Objects/Object Death Handler")]
    [RequireComponent(typeof(Health))]
    public class ObjectDeathHandler : MonoBehaviour, IDeathHandler
    {
        protected Health health;

        protected virtual void Awake() => health = GetComponent<Health>();

        private void OnEnable() => health.OnDeath += Die;

        private void OnDisable() => health.OnDeath -= Die;

        public virtual void Die() => Destroy(gameObject);
    }
}