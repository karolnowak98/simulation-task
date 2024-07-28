using System;
using GlassyCode.Simulation.Game.RandomNumber.Logic;
using Zenject;

namespace GlassyCode.Simulation.Game.RandomNumber.UI
{
    public sealed class RandomNumberUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(RandomNumberPanel), typeof(IInitializable), typeof(IDisposable))
                .To<RandomNumberPanel>()
                .FromComponentsInHierarchy()
                .AsSingle();
        }
    }
}