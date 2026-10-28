using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lab.Pooling
{
    public class ObjectPool
    {
        private readonly PoolData _data;
        private readonly Transform _parent;
        private readonly IObjectResolver _resolver;
        private readonly Queue<PooledEntity> _pool = new();

        private List<PooledEntity> _activeEntities = new();

        public ObjectPool(PoolData data, Transform parent, IObjectResolver resolver)
        {
            _data = data;
            _parent = parent;
            _resolver = resolver;

            for (int i = 0; i < _data.PoolSize; i++)
                _pool.Enqueue(CreateInstance());
        }

        public bool TryGet(out PooledEntity entity)
        {
            if (_pool.Count == 0)
            {
                if (!_data.CanGrow)
                {
                    entity = null;
                    return false;
                }

                _pool.Enqueue(CreateInstance());
            }

            entity = _pool.Dequeue();
            entity.gameObject.SetActive(true);
            entity.OnSpawn();

            _activeEntities.Add(entity);

            return true;
        }

        public void Return(PooledEntity entity)
        {
            if (!entity.gameObject.activeSelf)
                return;

            entity.OnDespawn();
            entity.gameObject.SetActive(false);

            _activeEntities.Remove(entity);

            _pool.Enqueue(entity);
        }

        private PooledEntity CreateInstance()
        {
            var instance = _resolver.Instantiate(_data.Prefab, _parent);
            instance.Bind(this);
            instance.gameObject.SetActive(false);
            return instance;
        }

        public void ReturnAll()
        {
            for (int i = _activeEntities.Count - 1; i >= 0; i--)
                _activeEntities[i].Return();
        }
    }
}