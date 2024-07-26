using GlassyCode.Simulation.Core.Applications.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Core.Applications.Logic
{
    public sealed class ApplicationController : IApplicationController, IInitializable
    {
        private IApplicationConfig _applicationConfig;

        [Inject]
        private void Construct(IApplicationConfig applicationConfig)
        {
            _applicationConfig = applicationConfig;
        }
        
        public void Initialize()
        {
            Application.targetFrameRate = _applicationConfig.TargetFps;
        }
    }
}