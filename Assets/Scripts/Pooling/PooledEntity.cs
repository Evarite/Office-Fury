using UnityEngine;

namespace Lab.Pooling
{
    public class PooledEntity : MonoBehaviour
    {
        private ObjectPool _pool;

        public void Bind(ObjectPool pool) => _pool = pool;

        public void Return() => _pool.Return(this);

        public virtual void OnSpawn() { }

        public virtual void OnDespawn() { }
    }
}