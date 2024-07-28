using System;
using Zenject;

namespace GlassyCode.Simulation.Game.Agents.UI
{
    public sealed class AgentsUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(IInitializable), typeof(IDisposable))
                .To<MainPanel>()
                .FromComponentsInHierarchy()
                .AsSingle();
        }
    }
}