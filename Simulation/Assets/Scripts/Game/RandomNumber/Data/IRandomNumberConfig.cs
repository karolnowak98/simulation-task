using UnityEngine;

namespace GlassyCode.Simulation.Game.RandomNumber.Data
{
    public interface IRandomNumberConfig
    {
        Vector2Int RandomNumberRange { get; }
        string DivisibleByThreeText { get; }
        string DivisibleByFiveText { get; }
        string DivisibleByFifteenText { get; }
    }
}