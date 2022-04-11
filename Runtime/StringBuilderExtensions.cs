using System;
using System.Text;
using UnityEngine;

namespace Jobus.Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder LineAppend(this StringBuilder builder, string str)
        {
            builder.Append(Environment.NewLine);
            builder.Append(str);
            return builder;
        }
    
        /// <summary>
        /// Append string using hex color-tagged rich text.
        /// </summary>
        /// <param name="colorHex">For example "FFFFFF" for white.</param>
        public static StringBuilder Append(this StringBuilder builder, string str, string colorHex)
        {
            if (char.IsDigit(colorHex[0]))
                builder.Append("<color=#");
            else
                builder.Append("<color=");
            
            builder.Append(colorHex);
            builder.Append(">");
            builder.Append(str);
            builder.Append("</color>");
            return builder;
        }
    
        /// <summary>
        /// Append string line using hex color-tagged rich text.
        /// </summary>
        /// <param name="colorHex">For example "FFFFFF" for white.</param>
        public static StringBuilder AppendLine(this StringBuilder builder, string str, string colorHex)
        {
            builder.Append(str, colorHex);
            builder.Append(Environment.NewLine);
            return builder;
        }
    
        /// <summary>
        /// Append new line, then append string using hex color-tagged rich text.
        /// </summary>
        /// <param name="colorHex">For example "FFFFFF" for white.</param>
        public static StringBuilder LineAppend(this StringBuilder builder, string str, string colorHex)
        {
            builder.Append(Environment.NewLine);
            builder.Append(str, colorHex);
            return builder;
        }
    
        /// <summary>
        /// Append string using color-tagged rich text.
        /// </summary>
        public static StringBuilder Append(this StringBuilder builder, string str, Color color)
        {
            return builder.Append(str, ColorUtility.ToHtmlStringRGBA(color));
        }
    
        /// <summary>
        /// Append string line using color-tagged rich text.
        /// </summary>
        public static StringBuilder AppendLine(this StringBuilder builder, string str, Color color)
        {
            return builder.AppendLine(str, ColorUtility.ToHtmlStringRGBA(color));
        }
    
        /// <summary>
        /// Append new line, then append string using color-tagged rich text.
        /// </summary>
        public static StringBuilder LineAppend(this StringBuilder builder, string str, Color color)
        {
            return builder.LineAppend(str, ColorUtility.ToHtmlStringRGBA(color));
        }

        /// <summary>
        /// Append start of rich text color tag. Should be combined with EndColor().
        /// </summary>
        /// <param name="colorHex">For example "FFFFFF" for white.</param>
        public static StringBuilder StartColor(this StringBuilder builder, string colorHex)
        {
            builder.Append("<color=");

            if (colorHex[0] != '#')
                builder.Append('#');
        
            builder.Append(colorHex).Append(">");
        
            return builder;
        }

        /// <summary>
        /// Append start of rich text color tag. Should be combined with EndColor().
        /// </summary>
        public static StringBuilder StartColor(this StringBuilder builder, Color color)
        {
            return builder.StartColor(ColorUtility.ToHtmlStringRGBA(color));
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