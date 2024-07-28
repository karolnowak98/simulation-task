using GlassyCode.Simulation.Core.Data;
using GlassyCode.Simulation.Game.Global.Static;
using UnityEngine;

namespace GlassyCode.Simulation.Game.Agents.Data
{
    [CreateAssetMenu(menuName = MenuNames.Configs + nameof(AgentsConfig), fileName = nameof(AgentsConfig))]
    public sealed class AgentsConfig : Config
    {
        [field: SerializeField] public SpawnerData Spawner { get; private set; }
    }
}