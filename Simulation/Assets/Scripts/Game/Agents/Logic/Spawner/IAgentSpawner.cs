namespace GlassyCode.Simulation.Game.Agents.Logic.Spawner
{
    public interface IAgentSpawner
    {
        void Tick();
        void StartSpawning();
        void StopSpawning();
        void SpawnInitialEnemies();
    }
}