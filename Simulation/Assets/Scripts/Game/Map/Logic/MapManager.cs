using GlassyCode.Simulation.Game.Map.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Game.Map.Logic
{
    public sealed class MapManager : IMapManager, IInitializable
    {
        public IMapConfig Config { get; }
        private readonly Transform _map;
        
        public MapManager(IMapConfig config, Transform map)
        {
            Config = config;
            _map = map;
        }
        
        public void Initialize()
        {
            SetMapSize(_map);
        }

        private void SetMapSize(Transform map)
        {
            map.localScale = Config.Size;
        }
    }
}