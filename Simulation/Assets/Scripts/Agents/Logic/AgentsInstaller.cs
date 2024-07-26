using GlassyCode.Simulation.Agents.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Agents.Logic
{
    public sealed class AgentsInstaller : MonoInstaller
    {
        [field: SerializeField] public AgentsConfig Config { get; private set; }
        
        public override void InstallBindings()
        {
            Container.Bind(typeof(AgentsManager), typeof(IAgentsManager))
                .To<AgentsManager>()
                .FromSubContainerResolve()
                .ByMethod(InstallAgents)
                .AsSingle()
                .WithArguments(Config);
        }

        public void InstallAgents(DiContainer subContainer)
        {
            //subContainer.Bind(typeof(AgentsManager)).AsSingle();

            subContainer.Bind(typeof(AgentsSpawner), typeof(IAgentsSpawner), typeof(ITickable))
                .To<AgentsSpawner>()
                .AsSingle()
                .WithArguments(Config.Spawner);

            subContainer.BindFactory<Object, AgentMono, AgentMono.Factory>().FromFactory<PrefabFactory<AgentMono>>();
        }
    }
}