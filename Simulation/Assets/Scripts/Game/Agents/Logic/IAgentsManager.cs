using GlassyCode.Simulation.Game.Agents.Logic.Collection;
using GlassyCode.Simulation.Game.Agents.Logic.Selector;
using GlassyCode.Simulation.Game.Agents.Logic.Spawner;

namespace GlassyCode.Simulation.Game.Agents.Logic
{
    public interface IAgentsManager
    {
        IAgentSpawner Spawner { get; }
        IAgentSelector Selector { get;}
        IAgentCollection Collection { get; }
        void Enable();
        void Disable();
    }
}