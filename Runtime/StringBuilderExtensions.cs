using System;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Jobus.Extensions
{
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Append string using hex color-tagged rich text.
        /// </summary>
        /// <param name="colorHex">For example "#ffffff" or "white" for white.</param>
        public static StringBuilder Append(this StringBuilder builder, string str, string colorHex)
        {
            builder.StartColor(colorHex);
            builder.Append(str);
            builder.EndColor();
            return builder;
        }
    
        /// <summary>
        /// Append string line using hex color-tagged rich text.
        /// </summary>
        /// <param name="colorHex">For example "#ffffff" or "white" for white.</param>
        public static StringBuilder AppendLine(this StringBuilder builder, string str, string colorHex)
        {
            builder.Append(str, colorHex);
            builder.Append(Environment.NewLine);
            return builder;
        }

        /// <summary>
        /// Append string using color-tagged rich text.
        /// </summary>
        public static StringBuilder Append(this StringBuilder builder, string str, Color color)
        {
            return builder.Append(str, '#' + ColorUtility.ToHtmlStringRGBA(color));
        }
    
        /// <summary>
        /// Append string line using color-tagged rich text.
        /// </summary>
        public static StringBuilder AppendLine(this StringBuilder builder, string str, Color color)
        {
            return builder.AppendLine(str, '#' + ColorUtility.ToHtmlStringRGBA(color));
        }

        /// <summary>
        /// Append start of rich text color tag. Should be combined with EndColor().
        /// </summary>
        /// <param name="colorHex">For example "#ffffff" or "white" for white.</param>
        public static StringBuilder StartColor(this StringBuilder builder, string colorHex)
        {
            builder.Append("<color=");
            builder.Append(colorHex);
            builder.Append(">");

            return builder;
        }

        /// <summary>
        /// Append start of rich text color tag. Should be combined with EndColor().
        /// </summary>
        public static StringBuilder StartColor(this StringBuilder builder, Color color)
        {
            return builder.StartColor('#' + ColorUtility.ToHtmlStringRGBA(color));
        }

        /// <summary>
        /// Append end of rich text color tag.
        /// </summary>
        public static StringBuilder EndColor(this StringBuilder builder)
        {
            return builder.Append("</color>");
        }
        
        /// <summary>
        /// Removes all the trailing white-space characters from the StringBuilder.
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
        
        /// <summary>
        /// Removes all the trailing occurrences of a character from the StringBuilder.
        /// </summary>
        public static StringBuilder TrimEnd(this StringBuilder sb, char trimChar)
        {
            if (sb == null || sb.Length == 0)
                return sb;

            int i = sb.Length - 1;
            for (; i >= 0; i--)
            {
                if (sb[i] != trimChar)
                    break;
            }

            if (i < sb.Length - 1)
                sb.Length = i + 1;

            return sb;
        }
        
        /// <summary>
        /// Removes all the trailing occurrences of a set of characters specified in an array from the StringBuilder.
        /// </summary>
        public static StringBuilder TrimEnd(this StringBuilder sb, params char[] trimChars)
        {
            if (sb == null || sb.Length == 0)
                return sb;

            int i = sb.Length - 1;
            for (; i >= 0; i--)
            {
                if (!trimChars.Contains(sb[i]))
                    break;
            }

            if (i < sb.Length - 1)
                sb.Length = i + 1;

            return sb;
        }
    }
}