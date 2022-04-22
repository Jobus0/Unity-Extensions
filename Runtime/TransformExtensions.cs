using System;
using UnityEngine;

namespace Jobus.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Get the hierarchical path of the transform.
        /// </summary>
        public static string GetPath(this Transform current)
        {
            if (current.parent == null)
                return current.name;
            return current.parent.GetPath() + "/" + current.name;
        }

        /// <summary>
        /// Get the hierarchical path of the transform, relative to a parent transform.
        /// </summary>
        /// <param name="relativeTo">A transform the path will be relative to. Must be a parent transform.</param>
        /// <returns></returns>
        public static string GetPath(this Transform current, Transform relativeTo)
        {
            if (current.parent == relativeTo)
                return current.name;
            return current.parent.GetPath(relativeTo) + "/" + current.name;
        }

        /// <summary>
        /// Set the hierarchical path to where the transform should be parented.
        /// </summary>
        /// <param name="path">Hierarchical path to parent.</param>
        /// <param name="worldPositionStays">If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.</param>
        public static void SetPath(this Transform current, string path, bool worldPositionStays = true)
        {
            int rootIndex = path.IndexOf('/');
            Transform parent = GameObject.Find(path.Substring(0, rootIndex)).transform;
            parent = parent.Find(path.Substring(rootIndex + 1));
            current.SetParent(parent, worldPositionStays);
        }

        /// <summary>
        /// Set the hierarchical path to where the transform should be parented, relative to a transform.
        /// </summary>
        /// <param name="relativeTo">A transform the path will be relative to.</param>
        /// <param name="path">Hierarchical path to parent.</param>
        /// <param name="worldPositionStays">If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.</param>
        public static void SetPath(this Transform current, Transform relativeTo, string path, bool worldPositionStays = true)
        {
            Transform parent = relativeTo;
            parent = parent.Find(path);
            current.SetParent(parent, worldPositionStays);
        }

        /// <summary>
        /// Get the hierarchical depth (the number of parent and grandparents) of the transform.
        /// </summary>
        public static int GetDepth(this Transform current)
        {
            int depth = 0;
            while (current.parent != null)
            {
                depth++;
                current = current.parent;
            }
            return depth;
        }
    
        /// <summary>
        ///   <para>Finds a child by name and returns it.</para>
        /// </summary>
        /// <param name="name">Name of child to be found.</param>
        /// <returns>
        ///   <para>The returned child transform or null if no child is found.</para>
        /// </returns>
        public static GameObject Find(this GameObject gameObject, string name)
        {
            if (name == null)
                throw new ArgumentNullException("Name cannot be null");
        
            return gameObject.transform.Find(name).gameObject;
        }
    }
}