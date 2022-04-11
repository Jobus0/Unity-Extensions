using UnityEngine;
using System.Collections;

namespace Jobus.Extensions
{
    /// <summary>
    /// Have an interface inherit this to get access to the 'gameObject', 'transform', 'GetComponent()' and other members you'd normally find in a MonoBehaviour.
    /// </summary>
    public interface IMonoBehaviour
    {
        /// <summary>
        /// The game object this component is attached to. A component is always attached to a game object.
        /// </summary>
        GameObject gameObject { get; }

        /// <summary>
        /// The Transform attached to this GameObject (null if there is none attached).
        /// </summary>
        Transform transform { get; }

        /// <summary>
        /// The name of the object.
        /// </summary>
        string name { get; set; }

        /// <summary>
        /// The tag of this game object.
        /// </summary>
        string tag { get; set; }

        /// <summary>
        /// Enabled Behaviours are Updated, disabled Behaviours are not.
        /// </summary>
        bool enabled { get; set; }

        /// <summary>
        /// Returns the component of Type T if the game object has one attached, null if it doesn't.
        /// </summary>
        /// <typeparam name="T">The type of Component to retrieve.</typeparam>
        T GetComponent<T>();

        /// <summary>
        /// Returns all components of Type T in the GameObject.
        /// </summary>
        /// <typeparam name="T">The type of Components to retrieve.</typeparam>
        T[] GetComponents<T>();

        bool TryGetComponent<T>(out T component);

        /// <summary>
        /// Returns the component of Type T in the GameObject or any of its parents.
        /// </summary>
        /// <typeparam name="T">The type of Component to retrieve.</typeparam>
        T GetComponentInParent<T>();

        /// <summary>
        /// Returns all components of Type T in the GameObject or any of its parents.
        /// </summary>
        /// <typeparam name="T">The type of Components to retrieve.</typeparam>
        T[] GetComponentsInParent<T>();

        /// <summary>
        /// Returns the component of Type T in the GameObject or any of its children using depth first search.
        /// </summary>
        /// <typeparam name="T">The type of Component to retrieve.</typeparam>
        T GetComponentInChildren<T>();

        /// <summary>
        /// Returns all components of Type T in the GameObject or any of its children.
        /// </summary>
        /// <typeparam name="T">The type of Components to retrieve.</typeparam>
        T[] GetComponentsInChildren<T>();

        /// <summary>
        /// Returns the instance id of the object.
        /// </summary>
        /// <returns></returns>
        int GetInstanceID();

        /// <summary>
        /// Returns the name of the game object.
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}