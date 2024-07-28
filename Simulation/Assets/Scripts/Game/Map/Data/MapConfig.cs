using GlassyCode.Simulation.Core.Data;
using GlassyCode.Simulation.Game.Global.Static;
using UnityEngine;

namespace GlassyCode.Simulation.Game.Map.Data
{
    [CreateAssetMenu(menuName = MenuNames.Configs + nameof(MapConfig), fileName = nameof(MapConfig))]
    public sealed class MapConfig : Config, IMapConfig
    {
        [field: SerializeField] public Vector3 Size { get; private set; }
    }
}