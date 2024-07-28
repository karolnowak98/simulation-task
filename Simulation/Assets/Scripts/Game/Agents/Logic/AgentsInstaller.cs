using System;
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
            Container.Bind(typeof(AgentsManager), typeof(IAgentsManager), 
                    typeof(ITickable), typeof(IDisposable), typeof(IEnableable))
                .To<AgentsManager>()
                .FromSubContainerResolve()
                .ByMethod(InstallAgents)
                .WithKernel()
                .AsSingle()
                .WithArguments(Config);

            DeclareSignals();
        }

        private void InstallAgents(DiContainer subContainer)
        {
            subContainer.Bind(typeof(AgentsManager), typeof(IAgentsManager), 
                typeof(ITickable), typeof(IDisposable), typeof(IEnableable))
                .To<AgentsManager>()
                .AsSingle();
            
            subContainer.Bind(typeof(AgentCollection), typeof(IAgentCollection), 
                    typeof(IInitializable), typeof(IDisposable))
                .To<AgentCollection>()
                .AsSingle();
            
            subContainer.Bind(typeof(AgentSelector), typeof(IAgentSelector))
                .To<AgentSelector>()
                .AsSingle();
            
            subContainer.Bind(typeof(AgentSpawner), typeof(IAgentSpawner))
                .To<AgentSpawner>()
                .AsSingle()
                .WithArguments(Config.Spawner, SpawnerArea);

            subContainer.BindFactory<Object, Agent, Agent.Factory>().FromFactory<PrefabFactory<Agent>>();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<AgentSpawnedSignal>();
            Container.DeclareSignal<AgentDiedSignal>();
        }
    }
}