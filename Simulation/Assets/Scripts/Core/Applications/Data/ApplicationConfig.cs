using GlassyCode.Simulation.Core.Data;
using GlassyCode.Simulation.Core.Static;
using UnityEngine;

namespace GlassyCode.Simulation.Core.Applications.Data
{
    [CreateAssetMenu(menuName = MenuNames.Configs + nameof(ApplicationConfig), fileName = nameof(ApplicationConfig))]
    public class ApplicationConfig : Config, IApplicationConfig
    {
        [field: SerializeField] public int TargetFps { get; private set; }
    }
}