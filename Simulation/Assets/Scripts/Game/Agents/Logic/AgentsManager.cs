using System;
using GlassyCode.Simulation.Core.Utility.Interfaces;
using GlassyCode.Simulation.Game.Agents.Logic.Collection;
using GlassyCode.Simulation.Game.Agents.Logic.Selector;
using GlassyCode.Simulation.Game.Agents.Logic.Spawner;
using Zenject;

namespace GlassyCode.Simulation.Game.Agents.Logic
{
    public sealed class AgentsManager : IAgentsManager, ITickable, IDisposable, IEnableable
    {
        private readonly IAgentSpawner _spawner;
        private readonly IAgentSelector _selector;
        private readonly IAgentCollection _collection;

        public AgentsManager(IAgentSpawner spawner, IAgentSelector selector, IAgentCollection collection)
        {
            _spawner = spawner;
            _selector = selector;
            _collection = collection;
        }
        
        public void Tick()
        {
            _spawner.Tick();
        }
        
        public void Dispose()
        {
            Disable();
        }

        public void Enable()
        {
            _selector.Enable();
            _spawner.SpawnInitialEnemies();
            _spawner.StartSpawning();
        }

        public void Disable()
        {
            _selector.Disable();
            _spawner.StopSpawning();
            _collection.Clear();
        }
    }
}