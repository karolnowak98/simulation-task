using UnityEngine;

namespace GlassyCode.Simulation.Core.Utility
{
    public static class PhysicsExtensions
    {
        public static Vector3? GetRayastHitPoint(Vector3 startingPoint, LayerMask layerMask)
        {
            var ray = new Ray(new Vector3(startingPoint.x, Mathf.Infinity, startingPoint.z), Vector3.down);

            return Physics.Raycast(ray, out var hit, Mathf.Infinity, layerMask) ? hit.point : null;
        }
        
        public static Vector3? GetRayastHitPoint(Vector2 startingPoint, LayerMask layerMask)
        {
            var ray = new Ray(new Vector3(startingPoint.x, Mathf.Infinity, startingPoint.x), Vector3.down);

            return Physics.Raycast(ray, out var hit, Mathf.Infinity, layerMask) ? hit.point : null;
        }
        
        public static Vector3? GetRayastHitPoint(Ray ray, LayerMask layerMask)
        {
            return Physics.Raycast(ray, out var hit, Mathf.Infinity, layerMask) ? hit.point : null;
        }
    }
}