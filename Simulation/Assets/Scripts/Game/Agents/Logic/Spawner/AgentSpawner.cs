using System;
using System.Collections.Generic;
using GlassyCode.Simulation.Core.Pools.Object;
using GlassyCode.Simulation.Core.Time;
using GlassyCode.Simulation.Core.Utility.Extensions;
using GlassyCode.Simulation.Game.Agents.Data;
using GlassyCode.Simulation.Game.Agents.Logic.Collection;
using GlassyCode.Simulation.Game.Agents.Logic.Signals;
using GlassyCode.Simulation.Game.Map.Logic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Game.Agents.Logic.Spawner
{
    public sealed class AgentSpawner : IAgentSpawner
    {
        private readonly Dictionary<AgentName, IGlassyObjectPool<Agent>> _agentsPools = new();
        private readonly IAgentCollection _agents;
        private readonly ITimer _timer;
        private readonly SignalBus _signalBus;
        private readonly int _maxAgentsNumber;
        private readonly int _initialAgentsNumber;

        public AgentSpawner(SpawnerData data, Collider area, ITimeController timeController, 
            Agent.Factory factory, SignalBus signalBus, IAgentCollection agents, IMapManager mapManager)
        {
            _signalBus = signalBus;
            _agents = agents;
            _maxAgentsNumber = data.MaxAgentsNumber;
            _initialAgentsNumber = data.InitialAgentsNumber;
            
            _timer = new RandomAutomaticTimer(timeController, data.IntervalRange);

            foreach (AgentName type in Enum.GetValues(typeof(AgentName)))
            {
                var agent = data.GetAgentByType(type);

                if (agent == null)
                {
                    continue;
                }

                _agentsPools[type] = new AgentPool(factory, area, agent, new GameObject(type + nameof(AgentPool)).transform, 
                    data.InitialPoolSize, data.MaxPoolSize);
            }
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
            for (var i = 0; i < _initialAgentsNumber - 1; i++)
            {
                SpawnAgent();
            }
        }
        
        private void SpawnAgent()
        {
            if (_agents.Count >= _maxAgentsNumber)
            {
                return;
            }
            
            if (_agentsPools.TryGetValue(AgentName.Adam.GetRandomValue(), out var pool))
            {
                var agent = pool.Pool.Get();
                _signalBus.TryFire(new AgentSpawnedSignal { Agent = agent });
            }
        }
    }
}