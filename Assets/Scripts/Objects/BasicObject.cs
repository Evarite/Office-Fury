using UnityEngine;

namespace Office.Objects
{
    [RequireComponent(typeof(Health))]
    public class BasicObject : MonoBehaviour, IHittable
    {
        protected Health _health;

        public virtual void Hit(float damage) => _health.TakeDamage(damage);
    }
}