using GlassyCode.Simulation.Agents.Data;
using GlassyCode.Simulation.Core.Data;
using GlassyCode.Simulation.Core.Static;
using UnityEngine;

namespace GlassyCode.Simulation.Map.Data
{
    [CreateAssetMenu(menuName = MenuNames.Configs + nameof(AgentsConfig), fileName = nameof(AgentsConfig))]
    public sealed class MapConfig : Config, IMapConfig
    {
        [field: SerializeField] public Vector2 Size { get; private set; }
    }
}