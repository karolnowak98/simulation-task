using GlassyCode.Simulation.Core.Data;
using GlassyCode.Simulation.Game.Global.Static;
using UnityEngine;

namespace GlassyCode.Simulation.Game.RandomNumber.Data
{
    [CreateAssetMenu(menuName = MenuNames.Configs + nameof(NumberConfig), fileName = nameof(NumberConfig))]
    public sealed class NumberConfig : Config, INumberConfig
    {
        [field: SerializeField] public Vector2Int RandomNumberRange { get; private set; }
        
        //With odin would be better to use Dictionary<int, string> -> <number, text>
        [field: SerializeField] public string DivisibleByThreeText { get; private set; }
        [field: SerializeField] public string DivisibleByFiveText { get; private set; }
        [field: SerializeField] public string DivisibleByFifteenText { get; private set; }
    }
}