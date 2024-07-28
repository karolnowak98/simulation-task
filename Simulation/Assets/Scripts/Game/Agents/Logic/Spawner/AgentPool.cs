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
            return _factory.Create(_agent, GetRandomPos(), Parent, this);
        }
        
        protected override void OnGetElementFromPool(Agent agent)
        {
            agent.SetPosition(GetRandomPos());
            base.OnGetElementFromPool(agent);
        }

        private Vector3 GetRandomPos()
        {
            var randomPos = _spawningArea.GetRandomPointInCollider();
            return new Vector3(randomPos.x, _agent.Position.y, randomPos.z);
        }
    }
}