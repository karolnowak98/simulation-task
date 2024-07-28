using UnityEngine;

namespace GlassyCode.Simulation.Core.Utility.Extensions
{
    public static class VectorExtensions
    {
        public static float GetRandomValue(this Vector2Int range)
        {
            return Random.Range(range.x, range.y);
        }
        
        public static float GetRandomValue(this Vector2 range)
        {
            return Random.Range(range.x, range.y);
        }
    }
}