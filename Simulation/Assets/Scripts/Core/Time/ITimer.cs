using System;

namespace GlassyCode.Simulation.Core.Time
{
    public interface ITimer
    {
        event Action OnExpired;
        event Action<float> OnTimerStarted;
        event Action OnTimerStopped;
        void Tick();
        void Start();
        void Stop();
        void Reset();
    }
}