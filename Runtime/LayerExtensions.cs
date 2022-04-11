using UnityEngine;

namespace Jobus.Extensions
{
    public static class LayerExtensions
    {
        /// <summary>
        /// Check if the layermask contains a specific layer.
        /// </summary>
        public static bool HasLayer(this LayerMask layerMask, int layerIndex)
        {
            return layerMask == (layerMask | (1 << layerIndex));
        }

        /// <summary>
        /// Set GameObject's layer by index. Optionally set layer of all children as well.
        /// </summary>
        /// <param name="layerIndex">Index of the layer to set it to.</param>
        /// <param name="includeChildren">Set layer of all its children.</param>
        public static void SetLayer(this GameObject gameObject, int layerIndex, bool includeChildren = false)
        {
            gameObject.layer = layerIndex;
        
            if (includeChildren)
            {
                foreach (Transform child in gameObject.transform)
                    child.gameObject.SetLayer(layerIndex, true);
            }
        }
    }
}