using GlassyCode.Simulation.Game.RandomNumber.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Game.RandomNumber.Logic
{
    public sealed class RandomNumberInstaller : MonoInstaller
    {
        [field: SerializeField] public RandomNumberConfig Config { get; private set; }
        
        public override void InstallBindings()
        {
            Container.Bind(typeof(RandomNumberManager), typeof(IRandomNumberManager))
                .To<RandomNumberManager>()
                .AsSingle()
                .WithArguments(Config);
        }
    }
}