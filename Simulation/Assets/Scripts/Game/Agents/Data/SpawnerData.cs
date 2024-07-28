using System;
using System.Linq;
using GlassyCode.Simulation.Game.Agents.Logic;
using GlassyCode.Simulation.Game.Global.Static;
using UnityEngine;

namespace GlassyCode.Simulation.Game.Agents.Data
{
    [Serializable]
    public struct SpawnerData : ISerializationCallbackReceiver
    {
        [Tooltip("In seconds")]
        [field: SerializeField] public Vector2 IntervalRange { get; private set; }
        [field: SerializeField, Range(3, 5)] public int InitialAgentsNumber { get; private set; }
        [field: SerializeField, Range(3, 100)] public int MaxAgentsNumber { get; private set; }
        [field: SerializeField] public Agent[] Agents { get; private set; }
        [field: SerializeField] public int InitialPoolSize { get; private set; }
        [field: SerializeField] public int MaxPoolSize { get; private set; }
        
        public Agent GetAgentByType(AgentName agentName) => Agents.FirstOrDefault(e => e.Data.Name == agentName);

        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            ValidateData();
        }

        private void ValidateData()
        {
            if (IntervalRange.x > IntervalRange.y)
            {
                Debug.LogError(Errors.IntervalRangeError);
            }

            if (InitialAgentsNumber > MaxAgentsNumber)
            {
                Debug.LogWarning(Warnings.InitialAgentsNumberWarning);
            }

            if (InitialPoolSize > MaxPoolSize)
            {
                Debug.LogError(Errors.InitialPoolSizeError);
            }
        }
    }
}