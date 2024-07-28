using Zenject;

namespace GlassyCode.Simulation.Core.Signals
{
    public sealed class SignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
        }
    }
}