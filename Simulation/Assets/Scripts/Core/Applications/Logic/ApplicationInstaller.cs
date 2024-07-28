using GlassyCode.Simulation.Core.Applications.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Core.Applications.Logic
{
    public sealed class ApplicationInstaller : MonoInstaller
    {
        [field: SerializeField] public ApplicationConfig Config { get; private set; }
        
        public override void InstallBindings()
        {
            Container.Bind(typeof(ApplicationController), typeof(IApplicationController), typeof(IInitializable))
                .To<ApplicationController>()
                .AsSingle()
                .WithArguments(Config)
                .NonLazy();
        }
    }
}