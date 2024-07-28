using System;
using Zenject;

namespace GlassyCode.Simulation.Game.RandomNumber.UI
{
    public sealed class NumberUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(NumberPanel), typeof(IInitializable), typeof(IDisposable))
                .To<NumberPanel>()
                .FromComponentsInHierarchy()
                .AsSingle();
        }
    }
}