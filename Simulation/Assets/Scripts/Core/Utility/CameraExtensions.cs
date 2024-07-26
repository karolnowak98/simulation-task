using UnityEngine;

namespace GlassyCode.Simulation.Core.Utility
{
    public static class CameraExtensions
    {
        public static Vector3[] ScreenCornersToWorldPoints()
        {
            var corners = new Vector3[4];
            for (var i = 0; i < 4; i++)
            {
                if (Camera.main == null) continue;
                
                var ray = Camera.main.ScreenPointToRay(new Vector2(i % 2 * Screen.width, 
                    i / 2f * Screen.height));
                if (Physics.Raycast(
                        ray,
                        out var hit,
                        10000f)
                   ) corners[i] = hit.point;
            }
            return corners;
        }
        public static Vector3? ScreenCornerToWorldPoint(Vector2 screenPoint)
        {
            if (Camera.main == null)
            {
                return null;
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(screenPoint), out var hit, 10000f))
            {
                return hit.point;
            }

            return null;
        }

        public static Vector3? LeftUpperScreenCornerToWorldPoint()
        {
            return ScreenCornerToWorldPoint(new Vector2(0, Screen.height));
        }

        public static Vector3? RightUpperScreenCornerToWorldPoint()
        {
            return ScreenCornerToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        public static Vector3? LeftBottomScreenCornerToWorldPoint()
        {
            return ScreenCornerToWorldPoint(new Vector2(0, 0));
        }

        public static Vector3? RightBottomScreenCornerToWorldPoint()
        {
            return ScreenCornerToWorldPoint(new Vector2(Screen.width, 0));
        }

        public static float? ScreenWidthToWorldDistance()
        {
            var leftBottom = LeftBottomScreenCornerToWorldPoint();
            var leftUpper = LeftUpperScreenCornerToWorldPoint();
            var rightBottom = RightBottomScreenCornerToWorldPoint();
            var rightUpper = RightUpperScreenCornerToWorldPoint();

            if (leftBottom.HasValue && leftUpper.HasValue)
            {
                return Vector3.Distance(leftBottom.Value, leftUpper.Value);
            }

            if (rightBottom.HasValue && rightUpper.HasValue)
            {
                return Vector3.Distance(rightBottom.Value, rightUpper.Value);
            }

            return null;
        }

        public static float? ScreenHeightToWorldDistance()
        {
            var leftUpper = LeftUpperScreenCornerToWorldPoint();
            var rightUpper = RightUpperScreenCornerToWorldPoint();
            var leftBottom = LeftBottomScreenCornerToWorldPoint();
            var rightBottom = RightBottomScreenCornerToWorldPoint();

            if (leftUpper.HasValue && rightUpper.HasValue)
            {
                return Vector3.Distance(leftUpper.Value, rightUpper.Value);
            }

            if (leftBottom.HasValue && rightBottom.HasValue)
            {
                return Vector3.Distance(leftBottom.Value, rightBottom.Value);
            }

            return null;
        }

        public static Rect? ScreenToRect()
        {
            var heightDistance = ScreenHeightToWorldDistance();
            var widthDistance = ScreenWidthToWorldDistance();

            if (!heightDistance.HasValue || !widthDistance.HasValue)
            {
                return null;
            }

            var leftBottom = LeftBottomScreenCornerToWorldPoint();
            var rightBottom = RightBottomScreenCornerToWorldPoint();
            var leftUpper = LeftUpperScreenCornerToWorldPoint();
            var rightUpper = RightUpperScreenCornerToWorldPoint();

            if (leftBottom.HasValue)
            {
                return new Rect(leftBottom.Value.x, leftBottom.Value.z, widthDistance.Value, heightDistance.Value);
            }

            if (rightBottom.HasValue)
            {
                return new Rect(rightBottom.Value.x, rightBottom.Value.z, widthDistance.Value, heightDistance.Value);
            }

            if (leftUpper.HasValue)
            {
                return new Rect(leftUpper.Value.x, leftUpper.Value.z, widthDistance.Value, heightDistance.Value);
            }

            if (rightUpper.HasValue)
            {
                return new Rect(rightUpper.Value.x, rightUpper.Value.z, widthDistance.Value, heightDistance.Value);
            }

            return null;
        }
    }
}