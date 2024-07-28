using GlassyCode.Simulation.Game.Agents.Data;

namespace GlassyCode.Simulation.Game.Agents.Logic
{
    public interface IAgent
    {
        AgentData Data { get; }
        int Health { get; }
        int MoveSpeed { get; }
        int Damage { get; }
    }
}