using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Office.Pooling
{
    [UsedImplicitly]
    public class PoolService : IInitializable
    {
        private readonly PoolData[] _datas;

        private readonly Dictionary<PooledEntity, ObjectPool> _pools = new();

        private readonly IObjectResolver _resolver;

        public PoolService(PoolData[] datas, IObjectResolver resolver)
        {
            _datas = datas;
            _resolver = resolver;
        }

        public void Initialize()
        {
            var root = new GameObject("Pools").transform;

            foreach (var data in _datas)
            {
                if (_pools.ContainsKey(data.Prefab))
                {
                    Debug.LogWarning($"Pool for {data.Prefab.name} already exists. Skipping.");
                    continue;
                }

                var parent = new GameObject($"{data.Prefab.name} Pool").transform;
                parent.SetParent(root);
                _pools.Add(data.Prefab, new ObjectPool(data, parent, _resolver));
            }
        }

        public bool TryGet(PooledEntity prefab, out PooledEntity entity)
        {
            if (_pools.TryGetValue(prefab, out var pool))
                if (pool.TryGet(out entity))
                    return true;

            Debug.LogError($"No registered pool for prefab: {prefab.name}");
            entity = null;
            return false;
        }

        public bool TryGet(PooledEntity prefab, Transform parent, out PooledEntity entity)
        {
            if (_pools.TryGetValue(prefab, out var pool))
                if (pool.TryGet(parent, out entity))
                    return true;

            Debug.LogError($"No registered pool for prefab: {prefab.name}");
            entity = null;
            return false;
        }

        public void ReturnAll()
        {
            foreach (var pool in _pools.Values)
                pool.ReturnAll();
        }
    }
}