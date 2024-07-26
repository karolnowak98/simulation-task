using GlassyCode.Simulation.Core.Applications.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Core.Applications.Logic
{
    public sealed class ApplicationInstaller : MonoInstaller
    {
        [SerializeField] private ApplicationConfig _applicationConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<IApplicationConfig>().To<ApplicationConfig>().FromInstance(_applicationConfig).AsSingle();
            
            Container.Bind(typeof(ApplicationController), typeof(IApplicationController), typeof(IInitializable))
                .To<ApplicationController>().AsSingle().NonLazy();
        }
    }
}