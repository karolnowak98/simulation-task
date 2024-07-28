using GlassyCode.Simulation.Core.Pools.Object;
using GlassyCode.Simulation.Core.Time;
using GlassyCode.Simulation.Game.Agents.Data;
using GlassyCode.Simulation.Game.Agents.Logic.Collection;
using GlassyCode.Simulation.Game.Agents.Logic.Signals;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Game.Agents.Logic.Spawner
{
    public sealed class AgentSpawner : IAgentSpawner
    {
        private readonly SignalBus _signalBus;
        private readonly IAgentCollection _agents;
        private readonly IGlassyObjectPool<Agent> _pool;
        private readonly ITimer _timer;
        private readonly int _maxAgentsNumber;
        private readonly int _initialAgentsNumber;

        public AgentSpawner(SpawnerData data, Collider area, ITimeController timeController, 
            Agent.Factory factory, SignalBus signalBus, IAgentCollection agents)
        {
            _signalBus = signalBus;
            _agents = agents;
            _maxAgentsNumber = data.MaxAgentsNumber;
            _initialAgentsNumber = data.InitialAgentsNumber;
            
            _pool = new AgentPool(factory, area, data.Agent, new GameObject(nameof(AgentSpawner)).transform);
            _timer = new RandomAutomaticTimer(timeController, data.IntervalRange);
        }
        
        public void Tick()
        {
            _timer.Tick();
        }
        
        public void StartSpawning()
        {
            _timer.OnExpired += SpawnAgent;
            _timer.Start();
        }

        public void StopSpawning()
        {
            _timer.OnExpired -= SpawnAgent;
            _timer.Stop();
        }

        public void SpawnInitialEnemies()
        {
            for (var i = 0; i < _initialAgentsNumber; i++)
            {
                SpawnAgent();
            }
        }
        
        private void SpawnAgent()
        {
            if (_maxAgentsNumber <= _agents.Count)
            {
                return;
            }
            
            var agent = _pool.Pool.Get();
            _signalBus.TryFire(new AgentSpawnedSignal{ Agent = agent });
        }
    }
}