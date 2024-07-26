using Zenject;

namespace GlassyCode.Simulation.Agents.Logic
{
    public sealed class AgentsManager : IAgentsManager, IInitializable
    {
        private IAgentsSpawner _spawner;
        
        [Inject]
        public void Construct(IAgentsSpawner spawner)
        {
            _spawner = spawner;
        }
        
        public void Initialize()
        {
            _spawner.EnableSpawning();
        }
    }
}