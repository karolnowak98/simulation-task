using System.Collections.Generic;

namespace GlassyCode.Simulation.Game.Agents.Logic.Collection
{
    public interface IAgentCollection
    {
        int Count { get; }
        void Add(IAgent agent);
        bool Remove(IAgent agent);
        IEnumerable<IAgent> GetAll();
        void Clear();
    }
}