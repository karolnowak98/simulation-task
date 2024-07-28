using System;
using GlassyCode.Simulation.Core.Utility.Extensions;
using UnityEngine;

namespace GlassyCode.Simulation.Core.Time
{
    public sealed class RandomAutomaticTimer : ITimer
    {
        private readonly ITimeController _timeController;
        private readonly Vector2 _intervalRange;
        
        private bool _isRunning;
        private float _remainingTime;
        
        public event Action<float> OnTimerStarted;
        public event Action OnTimerStopped;
        public event Action OnExpired;

        public RandomAutomaticTimer(ITimeController timeController, Vector2 intervalRange)
        {
            _timeController = timeController;
            _intervalRange = intervalRange;
        }

        public void Tick()
        {
            if (!_isRunning) return;
            
            var deltaTime = _timeController.DeltaTime;

            _remainingTime -= deltaTime;

            if (_remainingTime <= 0f)
            {
                OnExpired?.Invoke();
                Reset();
            }
        }
        
        public void Start()
        {
            _isRunning = true;
            OnTimerStarted?.Invoke(_remainingTime);
        }
        
        public void Stop()
        {
            _isRunning = false;
            OnTimerStopped?.Invoke();
        }

        public void Reset()
        {
            _remainingTime = _intervalRange.GetRandomValue();
        }
    }
}