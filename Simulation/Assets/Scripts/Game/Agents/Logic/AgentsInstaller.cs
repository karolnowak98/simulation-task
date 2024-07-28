using System;
using GlassyCode.Simulation.Core.Pools.Object;
using GlassyCode.Simulation.Core.Utility.Interfaces;
using GlassyCode.Simulation.Game.Agents.Data;
using GlassyCode.Simulation.Game.Agents.Logic.Collection;
using GlassyCode.Simulation.Game.Agents.Logic.Selector;
using GlassyCode.Simulation.Game.Agents.Logic.Signals;
using GlassyCode.Simulation.Game.Agents.Logic.Spawner;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace GlassyCode.Simulation.Game.Agents.Logic
{
    public sealed class AgentsInstaller : MonoInstaller
    {
        [field: SerializeField] public AgentsConfig Config { get; private set; }
        [field: SerializeField] public Collider SpawnerArea { get; private set; }
        
        public override void InstallBindings()
        {
            BindAgentsManager();
            BindAgentCollection();
            BindAgentSelector();
            BindAgentSpawner();
            DeclareSignals();
        }

        private void BindAgentsManager()
        {
            Container.Bind(typeof(AgentsManager), typeof(IAgentsManager), 
                    typeof(ITickable), typeof(IDisposable), typeof(IEnableable))
                .To<AgentsManager>()
                .FromSubContainerResolve()
                .ByMethod(InstallAgentsManager)
                .WithKernel()
                .AsSingle()
                .WithArguments(Config);
        }

        private void InstallAgentsManager(DiContainer subContainer)
        {
            subContainer.Bind(typeof(AgentsManager), typeof(IAgentsManager), 
                    typeof(ITickable), typeof(IDisposable), typeof(IEnableable))
                .To<AgentsManager>()
                .AsSingle();
        }

        private void BindAgentCollection()
        {
            Container.Bind(typeof(AgentCollection), typeof(IAgentCollection), 
                    typeof(IInitializable), typeof(IDisposable))
                .To<AgentCollection>()
                .AsSingle();
        }

        private void BindAgentSelector()
        {
            Container.Bind(typeof(AgentSelector), typeof(IAgentSelector))
                .To<AgentSelector>()
                .AsSingle();
        }

        private void BindAgentSpawner()
        {
            Container.Bind(typeof(AgentSpawner), typeof(IAgentSpawner))
                .To<AgentSpawner>()
                .AsSingle()
                .WithArguments(Config.Spawner, SpawnerArea);

            Container.BindFactory<Object, Vector3, Transform, IGlassyObjectPool<Agent>, Agent, Agent.Factory>()
                .FromFactory<PrefabFactory<Vector3, Transform, IGlassyObjectPool<Agent>, Agent>>();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<AgentSpawnedSignal>();
            Container.DeclareSignal<AgentDiedSignal>();
        }
    }
}