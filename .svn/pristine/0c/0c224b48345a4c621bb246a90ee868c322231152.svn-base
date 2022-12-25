using System.Collections.Generic;
using Core.Extension;
using UnityEngine;

namespace Core.PoolService
{
    public class Pool<T> where T : MonoBehAdv
    {
        private Queue<T> _content;
        private Transform _poolParent;

        public Pool(string poolName)
        {
            _content = new Queue<T>();
            _poolParent = new GameObject(poolName).transform;
        }

        public T Instantiate(T original)
        {
            if (_content.Count == 0)
            {
               return Object.Instantiate(original, _poolParent);
            }

            return _content.Dequeue();
        }

        public void Release(T poolObject)
        {
            _content.Enqueue(poolObject);
        }
    }
}