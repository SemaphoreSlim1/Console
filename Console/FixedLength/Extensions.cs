using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.FixedLength
{
    public static class Extensions
    {
        /// <summary>
        /// returns a substring on this string, and handles out of range cases
        /// </summary>
        /// <param name="str">The string to substring</param>
        /// <param name="startIndex">The starting index</param>
        /// <param name="length">the length of the desired substring</param>
        /// <returns>The substring</returns>
        public static String SafeSubstring(this String str, int startIndex, int length)
        { 
            if(startIndex > (str.Length -1)) //if we would be starting outside of the bounds of the string
            { return String.Empty; }

            if(startIndex + length > str.Length) //if we would be ending outside of the bounds of the string
            { return str.Substring(startIndex); } //start at the desired index, and just get the remainder of the string

            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// Returns a string that has been padded with spaces to a certain length
        /// </summary>
        /// <param name="str">The string to pad</param>
        /// <param name="length">The length of the final string</param>
        /// <returns>The padded string</returns>
        public static String PadTo(this String str, int length)
        {
            if(str.Length >= length)
            { return str; } //already at the defined length

            var sb = new StringBuilder(str);
            do
            {
                sb.Append(" ");
            } while (sb.Length < length);

            return sb.ToString();
        }
    }
}
