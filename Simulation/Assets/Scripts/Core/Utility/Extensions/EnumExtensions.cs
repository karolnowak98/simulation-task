using System;

namespace GlassyCode.Simulation.Core.Utility.Extensions
{
    public static class EnumExtensions
    {
        public static T GetRandomValue<T>(this T enumType) where T : Enum
        {
            var values = (T[])Enum.GetValues(enumType.GetType());
            var random = new Random();
            var index = random.Next(values.Length);
            return values[index];
        }
    }
}