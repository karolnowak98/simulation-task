using System;
using System.Collections.Generic;
using GlassyCode.Simulation.Game.Agents.Logic.Signals;
using Zenject;

namespace GlassyCode.Simulation.Game.Agents.Logic.Collection
{
    public sealed class AgentCollection : IAgentCollection, IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly HashSet<IAgent> _agents = new();
        
        public int Count => _agents.Count;
        
        public AgentCollection(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<AgentSpawnedSignal>(Add);
            _signalBus.Subscribe<AgentDiedSignal>(Remove);
        }
        
        public void Dispose()
        {
            _signalBus.TryUnsubscribe<AgentSpawnedSignal>(Add);
            _signalBus.TryUnsubscribe<AgentDiedSignal>(Remove);
        }

        public void Add(IAgent agent)
        {
            _agents.Add(agent);
        }

        public bool Remove(IAgent agent)
        {
            return _agents.Remove(agent);
        }

        public IEnumerable<IAgent> GetAll()
        {
            return _agents;
        }

        public void Clear()
        {
            _agents.Clear();
        }
        
        private void Add(AgentSpawnedSignal signal)
        {
            _agents.Add(signal.Agent);
        }
        
        private void Remove(AgentDiedSignal signal)
        {
            _agents.Remove(signal.Agent);
        }
    }
}