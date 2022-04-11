using UnityEngine;

namespace Jobus.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Returns a color with its alpha value multiplied.
        /// </summary>
        /// <param name="alphaMultiplier">Range 0 to 1. Multiplies the current alpha, so using 0.5 for a color that already has 0.5 alpha gives 0.25.</param>
        public static Color WithAlpha(this Color color, float alphaMultiplier)
        {
            color.a *= alphaMultiplier;
            return color;
        }
        
        /// <summary>
        /// Returns a color with its alpha value multiplied.
        /// </summary>
        /// <param name="alphaMultiplier">Range 0 to 1. Multiplies the current alpha, so using 0.5 for a color with 128 alpha gives 64.</param>
        public static Color WithAlpha(this Color32 color, float alphaMultiplier)
        {
            color.a = (byte)(color.a*alphaMultiplier);
            return color;
        }

        /// <summary>
        /// Returns a color with all its components offset by a single value.
        /// </summary>
        public static Color WithOffset(this Color color, float offset)
        {
            color.r = Mathf.Clamp01(color.r + offset);
            color.g = Mathf.Clamp01(color.g + offset);
            color.b = Mathf.Clamp01(color.b + offset);
            return color;
        }
    
        /// <summary>
        /// Returns a color with each component offset by a respective value.
        /// </summary>
        public static Color WithOffset(this Color color, float rOffset, float gOffset, float bOffset)
        {
            color.r = Mathf.Clamp01(color.r + rOffset);
            color.g = Mathf.Clamp01(color.g + gOffset);
            color.b = Mathf.Clamp01(color.b + bOffset);
            return color;
        }
    }
}