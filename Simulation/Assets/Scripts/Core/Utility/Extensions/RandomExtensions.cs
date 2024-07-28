using UnityEngine;

namespace GlassyCode.Simulation.Core.Utility.Extensions
{
    public static class RandomExtensions
    {
        public static int GetRandomNumber(this Vector2Int range)
        {
            return Random.Range(range.x, range.y);
        }
    }
}