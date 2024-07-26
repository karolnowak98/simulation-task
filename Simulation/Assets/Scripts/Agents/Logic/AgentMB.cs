using GlassyCode.Simulation.Agents.Data;
using GlassyCode.Simulation.Core.Utility;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Agents.Logic
{
    public sealed class AgentMono : GlassyMonoBehaviour
    {
        [field: SerializeField] public AgentData Data { get; private set; }
        
        
        public sealed class Factory : PlaceholderFactory<Object, AgentMono>{ }
    }
}