using UnityEngine;

namespace Core.Input
{
    public static class JoystickTools
    {
        public static void FormatInput(AxisOptions axisOptions, ref Vector2 input)
        {
            if (axisOptions == AxisOptions.Horizontal)
                input = new Vector2(input.x, 0f);
            if (axisOptions == AxisOptions.Vertical)
                input = new Vector2(0f, input.y);
        }

        public static void HandleInput(float magnitude, Vector2 normalized, float deadZone, ref Vector2 input)
        {
            if (magnitude > deadZone)
            {
                if (magnitude > 1) input = normalized;
            }
            else
            {
                input = Vector2.zero;
            }
        }

        public static float SnapFloat(float value, Vector2 input, AxisOptions axisOptions, AxisOptions snapAxis)
        {
            if (value == 0) return value;

            if (axisOptions == AxisOptions.Both)
            {
                var angle = Vector2.Angle(input, Vector2.up);
                if (snapAxis == AxisOptions.Horizontal)
                {
                    if (angle < 22.5f || angle > 157.5f) return 0;

                    return value > 0 ? -1 : 1;
                }

                if (snapAxis == AxisOptions.Vertical)
                {
                    if (angle > 67.5f && angle < 112.5f) return 0;

                    return value > 0 ? -1 : 1;
                }

                return value;
            }
            
            if (value > 0) return -1;
            if (value < 0) return 1;

            return 0;
        }
        
        public static Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition, RectTransform baseRect, Camera camera, RectTransform background)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(baseRect, screenPosition, camera, out var localPoint)) return Vector2.zero;
            
            var pivotOffset = baseRect.pivot * baseRect.sizeDelta;
            return localPoint - (background.anchorMax * baseRect.sizeDelta) + pivotOffset;
        }
    }
}