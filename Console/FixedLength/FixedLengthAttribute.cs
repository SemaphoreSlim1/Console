using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.FixedLength
{
    [AttributeUsage(AttributeTargets.Property, Inherited=false, AllowMultiple=false)]
    public sealed class FixedLengthAttribute : Attribute
    {
        /// <summary>
        /// Gets and sets the ordinal position of the attached property
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// Gets and sets the length for the attached property
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets and sets the value of the header for the attached property in the event headers are specified
        /// </summary>
        public String HeaderValue { get; set; }
    }
}
