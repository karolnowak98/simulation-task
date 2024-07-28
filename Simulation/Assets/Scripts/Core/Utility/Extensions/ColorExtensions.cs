using UnityEngine;

namespace GlassyCode.Simulation.Core.Utility.Extensions
{
    public static class ColorExtensions
    {
        public static Color GetRandomColor()
        {
            return new Color(Random.value, Random.value, Random.value);
        }
    }
}