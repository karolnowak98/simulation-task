using GlassyCode.Simulation.Agents.Data;
using Zenject;

namespace GlassyCode.Simulation.Agents.Logic
{
    public sealed class AgentsSpawner : IAgentsSpawner, ITickable
    {
        private SpawnerData _spawnerData;
        private bool _isSpawning;
        
        [Inject]
        private void Construct(SpawnerData spawnerData)
        {
            _spawnerData = spawnerData;
        }
        
        public void Tick()
        {
            if (!_isSpawning)
            {
                return;
            }
            
            //TODO if time passed
            SpawnEnemy();
        }

        public void EnableSpawning()
        {
            _isSpawning = true;
        }
        
        public void DisableSpawning()
        {
            _isSpawning = false;
        }

        public void SpawnEnemy()
        {
            
        }
    }

    public interface IAgentsSpawner
    {
        void SpawnEnemy();
    }
}