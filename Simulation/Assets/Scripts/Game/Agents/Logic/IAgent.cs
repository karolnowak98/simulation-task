using System;
using GlassyCode.Simulation.Game.Agents.Data;

namespace GlassyCode.Simulation.Game.Agents.Logic
{
    public interface IAgent
    {
        AgentData Data { get; }
        int Health { get; }
        int MoveSpeed { get; }
        int Damage { get; }
        event Action<int> OnHealthChanged;
        event Action OnDied;
        void Select();
        void Deselect();
    }
}