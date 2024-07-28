using GlassyCode.Simulation.Game.RandomNumber.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Game.RandomNumber.Logic
{
    public sealed class NumberInstaller : MonoInstaller
    {
        [field: SerializeField] public NumberConfig Config { get; private set; }
        
        public override void InstallBindings()
        {
            Container.Bind(typeof(NumberManager), typeof(INumberManager))
                .To<NumberManager>()
                .AsSingle()
                .WithArguments(Config);
        }
    }
}