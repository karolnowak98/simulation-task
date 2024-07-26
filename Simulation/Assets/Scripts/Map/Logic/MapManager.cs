using GlassyCode.Simulation.Map.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Simulation.Map.Logic
{
    public sealed class MapManager
    {
        private IMapConfig _config;
        
        [Inject]
        private void Construct(IMapConfig config, Transform map)
        {
            _config = config;
            
            SetMapSize(map);
        }

        private void SetMapSize(Transform map)
        {
            var size = _config.Size;

            map.localScale = new Vector3(size.x, map.localScale.y, size.y);
        }
    }
}