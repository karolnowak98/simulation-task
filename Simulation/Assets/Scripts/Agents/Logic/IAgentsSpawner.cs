namespace GlassyCode.Simulation.Agents.Logic
{
    public interface IAgentsSpawner
    {
        void EnableSpawning();
        void DisableSpawning();
        void SpawnEnemy();
    }
}