using System;
using System.Linq;
using GlassyCode.Simulation.Game.Agents.Logic;
using UnityEngine;

namespace GlassyCode.Simulation.Game.Agents.Data
{
    [Serializable]
    public struct SpawnerData
    {
        [Tooltip("In seconds")]
        [field: SerializeField] public Vector2 IntervalRange { get; private set; }
        [field: SerializeField, Range(3, 5)] public int InitialAgentsNumber { get; private set; }
        [field: SerializeField] public int MaxAgentsNumber { get; private set; }
        [field: SerializeField] public Agent[] Agents { get; private set; }
        
        public Agent GetAgentByType(AgentType agentType) => Agents.FirstOrDefault(e => e.Data.Type == agentType);
    }
}