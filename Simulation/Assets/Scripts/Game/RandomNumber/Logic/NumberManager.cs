using System;
using GlassyCode.Simulation.Core.Utility.Extensions;
using GlassyCode.Simulation.Game.RandomNumber.Data;

namespace GlassyCode.Simulation.Game.RandomNumber.Logic
{
    public sealed class NumberManager : INumberManager
    {
        private int _number;
        public int Number
        {
            get => _number;
            private set
            {
                if (_number == value)
                {
                    return;
                }
                
                _number = value;
                OnRandomNumberChanged?.Invoke(_number);
            }
        }
        
        public INumberConfig Config { get; }
        public bool IsDivisibleByThree => Number % 3 == 0;
        public bool IsDivisibleByFive => Number % 5 == 0;
        public bool IsDivisibleByFifteen => Number % 15 == 0;

        public event Action<int> OnRandomNumberChanged;

        public NumberManager(INumberConfig config)
        {
            Config = config;
        }

        public void GenerateRandomNumber()
        {
            Number = Config.RandomNumberRange.GetRandomNumber();
            OnRandomNumberChanged?.Invoke(Number);
        }
    }
}