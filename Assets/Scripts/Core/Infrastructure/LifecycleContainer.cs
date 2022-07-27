using System.Collections.Generic;
using UnityEngine;

namespace Core.Infrastructure
{
    public class LifecycleContainer : MonoBehaviour
    {
        private readonly List<object> _objects = new List<object>();
        
        public LifecycleContainer Add(object obj)
        {
            _objects.Add(obj);

            return this;
        }

        public void Start()
        {
            foreach (var obj in _objects)
            {
                if (obj is IStartable startable)
                {
                    startable.OnStart();
                }
            }
        }

        public void OnDestroy()
        {
            foreach (var obj in _objects)
            {
                if (obj is IDestroyable destroyable)
                {
                    destroyable.OnDestroy();
                }
            }
        }
    }
}