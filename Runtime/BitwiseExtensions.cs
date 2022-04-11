using System;

namespace Jobus.Extensions
{
    public static class BitwiseExtensions
    {
        /// <summary>
        /// Count the number of flags in an enum. Only returns a correct value from flag enums.
        /// </summary>
        public static int CountFlags(this Enum e)
        {
            return CountBits(Convert.ToInt32(e));
        }

        /// <summary>
        /// Count the number of bits in the integer.
        /// </summary>
        public static int CountBits(this int value)
        {
            int count = 0;

            while (value != 0)
            {
                value = value & (value - 1);
                count++;
            }

            return count;
        }
    }
}