using System;
using GlassyCode.Simulation.Game.RandomNumber.Data;

namespace GlassyCode.Simulation.Game.RandomNumber.Logic
{
    public interface IRandomNumberManager
    {
        IRandomNumberConfig Config { get; }
        int Number { get; }
        bool IsDivisibleByThree { get; }
        bool IsDivisibleByFive { get; }
        bool IsDivisibleByFifteen { get; }
        event Action<int> OnRandomNumberChanged;
        void RandomNumber();
    }
}