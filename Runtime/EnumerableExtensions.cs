using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Jobus.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Concatenate two arrays.
        /// </summary>
        public static T[] Concat<T>(this T[] first, T[] second)
        {
            T[] newArray = new T[first.Length + second.Length];
            int index = 0;
        
            for (int i = 0; i < first.Length; i++)
                newArray[index++] = first[i];
        
            for (int i = 0; i < second.Length; i++)
                newArray[index++] = second[i];
        
            return newArray;
        }

        ///<summary>Finds the index of the first item matching an expression in an enumerable.</summary>
        ///<param name="items">The enumerable to search.</param>
        ///<param name="predicate">The expression to test the items against.</param>
        ///<returns>The index of the first matching item, or -1 if no items match.</returns>
        public static int FindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            int retVal = 0;
            foreach (T item in items)
            {
                if (predicate(item))
                    return retVal;
                retVal++;
            }

            return -1;
        }

        ///<summary>Finds the index of the first occurence of an item in an enumerable.</summary>
        ///<param name="items">The enumerable to search.</param>
        ///<param name="item">The item to find.</param>
        ///<returns>The index of the first matching item, or -1 if the item was not found.</returns>
        public static int IndexOf<T>(this IEnumerable<T> items, T item)
        {
            return items.FindIndex(i => EqualityComparer<T>.Default.Equals(item, i));
        }

        /// <summary>
        /// Pick a random object from the array.
        /// </summary>
        public static T Random<T>(this T[] array)
        {
            int length = array.Length;

            if (length == 0)
                return default;

            return array[UnityEngine.Random.Range(0, length)];
        }

        /// <summary>
        /// Pick a random object from the list.
        /// </summary>
        public static T Random<T>(this IList<T> list)
        {
            int count = list.Count;

            if (count == 0)
                return default;

            return list[UnityEngine.Random.Range(0, count)];
        }

        public static bool AddNonNull<T>(this HashSet<T> set, T item) where T : class
        {
            if (item == null || item.Equals(null))
                return false;

            return set.Add(item);
        }

        private static StringBuilder toArrayStringStringBuilderCache;
        
        /// <summary>
        /// Returns a string listing each value in the array.
        /// </summary>
        public static string ToArrayString<T>(this IEnumerable<T> items, bool skipType = false, bool skipBrackets = false)
        {
            if (toArrayStringStringBuilderCache == null)
                toArrayStringStringBuilderCache = new StringBuilder();
            
            StringBuilder builder = toArrayStringStringBuilderCache;
            
            builder.Clear();
            
            if (!skipType)
                builder.Append(items);

            if (!skipBrackets)
                builder.Append(" { ");
        
            int i = 0;
            foreach (var item in items)
            {
                if (i > 0)
                    builder.Append(", ");

                if (item != null)
                    builder.Append(item.ToString().Replace($" ({typeof(T).FullName})", string.Empty));
                else
                    builder.Append("null");
            
                i++;
            }

            if (!skipBrackets)
                builder.Append(" } ");
        
            return builder.ToString();
        }

        /// <summary>
        /// Add all enum values as integers to list.
        /// </summary>
        public static void AddEnumValues<T>(this IList<int> list, params T[] enumValues) where T : struct, IConvertible
        {
            foreach (T enumValue in enumValues)
                list.Add(enumValue.ToInt32(CultureInfo.InvariantCulture.NumberFormat));
        }

        /// <summary>
        /// Dequeue, or return null if queue is empty.
        /// </summary>
        public static T DequeueOrNull<T>(this Queue<T> queue) where T : class
        {
            try
            {
                return queue.Dequeue();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    
        /// <summary>
        /// Try dequeue value. Returns true and outputs valid object if dequeuing was possible, otherwise returns false and outputs null.
        /// </summary>
        public static bool TryDequeue<T>(this Queue<T> queue, out T value) where T : class
        {
            try
            {
                value = queue.Dequeue();
            }
            catch (InvalidOperationException)
            {
                value = null;
            }

            return value != null;
        }
    
        /// <summary>
        /// Pop, or return null if stack is empty.
        /// </summary>
        public static T PopOrNull<T>(this Stack<T> stack) where T : class
        {
            try
            {
                return stack.Pop();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    
        /// <summary>
        /// Try pop value. Returns true and outputs valid object if popping was possible, otherwise returns false and outputs null.
        /// </summary>
        public static bool TryPop<T>(this Stack<T> queue, out T value) where T : class
        {
            try
            {
                value = queue.Pop();
            }
            catch (InvalidOperationException)
            {
                value = null;
            }

            return value != null;
        }
    
        /// <summary>
        /// Peek, or return null if stack is empty.
        /// </summary>
        public static T PeekOrNull<T>(this Stack<T> stack) where T : class
        {
            try
            {
                return stack.Peek();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    
        /// <summary>
        /// Try peek value. Returns true and outputs valid object if popping was possible, otherwise returns false and outputs null.
        /// </summary>
        public static bool TryPeek<T>(this Stack<T> queue, out T value) where T : class
        {
            try
            {
                value = queue.Peek();
            }
            catch (InvalidOperationException)
            {
                value = null;
            }

            return value != null;
        }
    
        /// <summary>
        /// Enumerate until predicate fails.
        /// </summary>
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var item in enumerable)
            {
                if (!predicate(item))
                    break;
            
                yield return item;
            }
        }
    
        /// <summary>
        /// Randomizes enumeration order using UnityEngine.Random.
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> RandomizedOrder<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(item => UnityEngine.Random.value);
        }

        /// <summary>
        /// Returns true if collection contains all values.
        /// </summary>
        public static bool ContainsAll<T>(this ICollection<T> source, IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                if (!source.Contains(value))
                    return false;
            }
            return true;
        }
    
        /// <summary>
        /// Add all enumerable values.
        /// </summary>
        public static void AddAll<T>(this ICollection<T> source, IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                source.Add(value);
            }
        }
    
        /// <summary>
        /// Remove all enumerable values.
        /// </summary>
        public static void RemoveAll<T>(this ICollection<T> source, IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                source.Remove(value);
            }
        }

        /// <summary>
        /// Uses GetComponent to select a single component of the specified type for each element.
        /// </summary>
        public static IEnumerable<T> SelectComponent<T>(this IEnumerable<GameObject> source)
        {
            foreach (var s in source)
                if (s.TryGetComponent(out T component))
                    yield return component;
        }
    
        /// <summary>
        /// Uses GetComponents to select all components of the specified type for each element.
        /// </summary>
        public static IEnumerable<T> SelectComponents<T>(this IEnumerable<GameObject> source)
        {
            foreach (var s in source)
            foreach (var component in s.GetComponents<T>())
                yield return component;
        }
    
        /// <summary>
        /// Get the average vector from a list of vectors.
        /// </summary>
        public static Vector3 Average(this IEnumerable<Vector3> vectors)
        {
            int count = 0;
            Vector3 average = Vector3.zero;
            foreach (var vector in vectors)
            {
                average += vector;
                count++;
            }

            return average/count;
        }

        /// <summary>
        /// Get the average quaternion from a list of quaternions.
        /// </summary>
        public static Quaternion Average(this IEnumerable<Quaternion> quaternions)
        {
            Quaternion average = Quaternion.identity;
             
            int amount = 0;                    
            foreach (var quaternion in quaternions)
                average = Quaternion.Slerp(average, quaternion, 1f/++amount);

            return average;
        }

        /// <summary>
        /// Dispose all disposables in a list.
        /// </summary>
        public static void DisposeAll(this IEnumerable<IDisposable> disposables)
        {
            foreach (var disposable in disposables)
                disposable.Dispose();
        }
    }
}