using GlassyCode.Simulation.Core.Data;
using GlassyCode.Simulation.Core.Static;
using UnityEngine;

namespace GlassyCode.Simulation.Agents.Data
{
    [CreateAssetMenu(menuName = MenuNames.Configs + nameof(AgentsConfig), fileName = nameof(AgentsConfig))]
    public sealed class AgentsConfig : Config
    {
        [field: SerializeField] public SpawnerData Spawner { get; private set; }
    }
}