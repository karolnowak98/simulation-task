using Zenject;

namespace GlassyCode.Simulation.Core.Time
{
    public sealed class TimeControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITimeController>().To<TimeController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}
