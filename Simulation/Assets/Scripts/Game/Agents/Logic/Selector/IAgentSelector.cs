using System;

namespace GlassyCode.Simulation.Game.Agents.Logic.Selector
{
    public interface IAgentSelector
    {
        event Action<IAgent> OnAgentSelected;
        event Action OnAgentDeselected;
        event Action<int> OnSelectedAgentHealthChanged;
        void Enable();
        void Disable();
    }
}