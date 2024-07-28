using GlassyCode.Simulation.Core.Pools.Object;
using GlassyCode.Simulation.Core.Utility.Extensions;
using UnityEngine;

namespace GlassyCode.Simulation.Game.Agents.Logic.Spawner
{
    public sealed class AgentPool : GlassyObjectPool<Agent>
    {
        private readonly Agent.Factory _factory;
        private readonly Collider _spawningArea;
        private readonly Agent _agent;
        
        public AgentPool(Agent.Factory factory, Collider spawningArea, Agent prefab, Transform parent, int initialSize = 10, int maxSize = 10000) 
            : base(prefab, parent, initialSize, maxSize)
        {
            _factory = factory;
            _spawningArea = spawningArea;
            _agent = prefab;
        }

        protected override Agent CreateElement()
        {
            var agent = _factory.Create(_agent);
            
            agent.SetPosition(_spawningArea.GetRandomPointInCollider());
            agent.SetParent(Parent);
            agent.Pool = this;
            
            return agent;
        }
        
        protected override void OnGetElementFromPool(Agent agent)
        {
            agent.SetPosition(_spawningArea.GetRandomPointInCollider());
            base.OnGetElementFromPool(agent);
        }
    }
}