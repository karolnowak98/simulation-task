using GlassyCode.Simulation.Map.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Map.Logic
{
    public sealed class MapInstaller : MonoInstaller
    {
        [field: SerializeField] public MapConfig Config { get; private set; }
        [field: SerializeField] public Transform Map { get; private set; }
        
        public override void InstallBindings()
        {
            Container.Bind(typeof(MapManager), typeof(IMapManager))
                .To<MapManager>()
                .AsSingle()
                .WithArguments(Config, Map);
        }
    }
}