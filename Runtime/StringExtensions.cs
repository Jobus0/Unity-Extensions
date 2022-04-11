using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Jobus.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Trim whitespace from string ending.
        /// </summary>
        public static StringBuilder TrimEnd(this StringBuilder sb)
        {
            if (sb == null || sb.Length == 0)
                return sb;

            int i = sb.Length - 1;
            for (; i >= 0; i--)
            {
                if (!char.IsWhiteSpace(sb[i]))
                    break;
            }

            if (i < sb.Length - 1)
                sb.Length = i + 1;

            return sb;
        }
    
        private static StringBuilder splitPascalCaseStringBuilderCache = new StringBuilder();
        
        /// <summary>
        /// Turns pascal case strings like "AllYourBase" into "All Your Base".
        /// </summary>
        public static string SplitPascalCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            splitPascalCaseStringBuilderCache.Clear();

            if (char.IsLetter(str[0]))
                splitPascalCaseStringBuilderCache.Append(char.ToUpper(str[0]));
            else
                splitPascalCaseStringBuilderCache.Append(str[0]);

            for (int i = 1; i < str.Length; i++)
            {
                char c = str[i];
                
                if (char.IsUpper(c) && !char.IsUpper(str[i - 1]))
                    splitPascalCaseStringBuilderCache.Append(' ');

                splitPascalCaseStringBuilderCache.Append(c);
            }

            return splitPascalCaseStringBuilderCache.ToString();
        }

        /// <summary>
        /// Turns camel case strings like "allYourBase" into "All Your Base".
        /// </summary>
        public static string SplitCamelCase(this string str)
        {
            str = Regex.Replace(
                Regex.Replace(
                    str,
                    @"(\P{Ll})(\P{Ll}\p{Ll})",
                    "$1 $2"
                ),
                @"(\p{Ll})(\P{Ll})",
                "$1 $2"
            );
            str = str.Replace(" - ", "-");
            str = str.Replace("  ", " ");
            return str.UppercaseFirstLetter();
        }

        public static string UppercaseFirstLetter(this string str)
        {
            return str.First().ToString().ToUpper() + str.Substring(1);
        }

        public static string LowercaseFirstLetter(this string str)
        {
            return str.First().ToString().ToLower() + str.Substring(1);
        }

        /// <summary>
        /// Encapsulates the string in a <color></color> markup format for use with rich text UIs.
        /// </summary>
        /// <param name="colorHex">For example "FFFFFF" for white.</param>
        public static string WithColor(this string str, string colorHex)
        {
            return $"<color=#{colorHex}>{str}</color>";
        }

        /// <summary>
        /// Encapsulates the string in a <color></color> markup format for use with rich text UIs.
        /// </summary>
        public static string WithColor(this string str, Color color)
        {
            return WithColor(str, ColorUtility.ToHtmlStringRGBA(color));
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified string are removed.
        /// </summary>
        public static string Remove(this string str, string remove)
        {
            return str.Replace(remove, string.Empty);
        }
    }
}