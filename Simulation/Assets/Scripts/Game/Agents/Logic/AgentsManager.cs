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
        public IAgentSpawner Spawner { get; }
        public IAgentSelector Selector { get; }
        public IAgentCollection Collection { get; }

        public AgentsManager(IAgentSpawner spawner, IAgentSelector selector, IAgentCollection collection)
        {
            Spawner = spawner;
            Selector = selector;
            Collection = collection;
        }
        
        public void Tick()
        {
            Spawner.Tick();
        }
        
        public void Dispose()
        {
            Disable();
        }

        public void Enable()
        {
            Selector.Enable();
            Spawner.SpawnInitialEnemies();
            Spawner.StartSpawning();
        }

        public void Disable()
        {
            Selector.Disable();
            Spawner.StopSpawning();
            Collection.Clear();
        }
    }
}