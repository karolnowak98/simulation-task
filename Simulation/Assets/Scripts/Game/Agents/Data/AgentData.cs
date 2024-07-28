using GlassyCode.Simulation.Core.Data;
using GlassyCode.Simulation.Game.Global.Static;
using UnityEngine;

namespace GlassyCode.Simulation.Game.Agents.Data
{
    [CreateAssetMenu(menuName = MenuNames.Agents + nameof(AgentData), fileName = nameof(AgentData))]
    public sealed class AgentData : EntityData
    {
        [field: SerializeField] public AgentName Name { get; private set; } 
        [field: SerializeField] public int InitialHealth { get; private set; } 
        [field: SerializeField] public int MoveSpeed { get; private set; } 
        [field: SerializeField] public int Damage { get; private set; }
    }
}