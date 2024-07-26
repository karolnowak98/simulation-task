using UnityEngine;
using UnityEngine.Pool;

namespace GlassyCode.Simulation.Core.Pools.Object
{
    public interface IGlassyObjectPool<T> where T : GlassyObjectPoolElement<T>
    {
        IObjectPool<T> Pool { get; }
        void Clear();
        void SetPoolParent(Transform parent);
    }
}