using GlassyCode.Simulation.Core.Utility;

namespace GlassyCode.Simulation.Core.Pools.Object
{
    public abstract class GlassyObjectPoolElement<T> : GlassyMonoBehaviour where T : GlassyObjectPoolElement<T>
    {
        public IGlassyObjectPool<T> Pool { get; set; }

        public abstract void Reset();
    }
}