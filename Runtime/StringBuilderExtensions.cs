using System;
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
    }
}