using Office.HealthSystem;
using Office.Weapons;
using UnityEngine;

namespace Office.Objects
{
    /// <summary>
    /// BasicObject is the base central class of an object.
    /// </summary>
    [AddComponentMenu("Office/Objects/BasicObject")]
    [RequireComponent(typeof(Health))]
    public class BasicObject : MonoBehaviour, IHittable
    {
        protected Health _health;

        public virtual void Hit(float damage) => _health.TakeDamage(damage);
    }
}