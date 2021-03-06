using System;
using System.Reflection;
using UnityEngine;

namespace Jobus.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Returns the component of Type T at index if the game object has that many attached, null if it doesn't.
        /// </summary>
        /// <typeparam name="T">The type of Component to retrieve.</typeparam>
        public static T GetComponent<T>(this GameObject gameObject, int index)
        {
            if (index == 0)
                return gameObject.GetComponent<T>();

            return gameObject.GetComponents<T>()[index];
        }
        
        /// <summary>
        /// Returns the component of Type T at index if the game object has that many attached, null if it doesn't.
        /// </summary>
        /// <typeparam name="T">The type of Component to retrieve.</typeparam>
        public static T GetComponent<T>(this Component component, int index)
        {
            if (index == 0)
                return component.GetComponent<T>();

            return component.GetComponents<T>()[index];
        }
        
        /// <summary>
        /// Returns the component of Type T at index if the game object has that many attached, null if it doesn't.
        /// </summary>
        /// <typeparam name="T">The type of Component to retrieve.</typeparam>
        public static T GetComponent<T>(this IMonoBehaviour monoBehaviour, int index)
        {
            if (index == 0)
                return monoBehaviour.GetComponent<T>();

            return monoBehaviour.GetComponents<T>()[index];
        }
        
        /// <summary>
        /// Returns true and outputs component if a component of type T at index is found, false and null otherwise.
        /// </summary>
        /// <typeparam name="T">The type of Component to retrieve.</typeparam>
        public static bool TryGetComponent<T>(this GameObject gameObject, int index, out T component) where T : class
        {
            if (index == 0)
                return gameObject.TryGetComponent(out component);

            var components = gameObject.GetComponents<T>();

            if (components.Length - 1 >= index)
            {
                component = components[index];
                return true;
            }

            component = null;
            return false;
        }
        
        /// <summary>
        /// Returns true and outputs component if a component of type T at index is found, false and null otherwise.
        /// </summary>
        /// <typeparam name="T">The type of Component to retrieve.</typeparam>
        public static bool TryGetComponent<T>(this Component component, int index, out T outComponent) where T : class
        {
            if (index == 0)
                return component.TryGetComponent(out outComponent);

            var components = component.GetComponents<T>();

            if (components.Length - 1 >= index)
            {
                outComponent = components[index];
                return true;
            }

            outComponent = null;
            return false;
        }
        
        /// <summary>
        /// Returns true and outputs component if a component of type T at index is found, false and null otherwise.
        /// </summary>
        /// <typeparam name="T">The type of Component to retrieve.</typeparam>
        public static bool TryGetComponent<T>(this IMonoBehaviour monoBehaviour, int index, out T component) where T : class
        {
            if (index == 0)
                return monoBehaviour.TryGetComponent(out component);

            var components = monoBehaviour.GetComponents<T>();

            if (components.Length - 1 >= index)
            {
                component = components[index];
                return true;
            }

            component = null;
            return false;
        }
        
        /// <summary>
        /// Adds a new component by coping the values of an existing one. Warning: Uses reflection (low performance).
        /// </summary>
        public static T AddComponentCopy<T>(this GameObject gameObject, T componentToCopy) where T : Component
        {
            T copy = (T)gameObject.AddComponent(componentToCopy.GetType());
            copy.CopyValuesFrom(componentToCopy);
            return copy;
        }

        /// <summary>
        /// Copies the values from a component to this component. Warning: Uses reflection (low performance).
        /// </summary>
        public static void CopyValuesFrom<T>(this T comp, T other) where T : Component
        {
            Type type = comp.GetType();
        
            if (type != other.GetType())
                return; // type mis-match
        
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
            PropertyInfo[] pinfos = type.GetProperties(flags);
            foreach (var pinfo in pinfos)
            {
                if (pinfo.CanWrite)
                {
                    try
                    {
                        pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                    }
                    catch
                    {
                        // ignored - in case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                    }
                }
            }
        
            FieldInfo[] finfos = type.GetFields(flags);
            foreach (var finfo in finfos)
            {
                finfo.SetValue(comp, finfo.GetValue(other));
            }
        }
    }
}