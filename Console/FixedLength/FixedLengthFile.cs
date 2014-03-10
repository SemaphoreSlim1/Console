using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Console.FixedLength
{
    public class FixedLengthFile
    {
        protected void InstantiateDefaults()
        {
            var properties = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach(var p in properties)
            {
                if(p.PropertyType == typeof(String))
                { p.SetValue(this, String.Empty, null); }
                else if(p.PropertyType == typeof(DateTime))
                { p.SetValue(this, DateTime.UtcNow, null); }
            }
        }

        /// <summary>
        /// Writes the headers of the specified type to the console
        /// </summary>
        /// <param name="fileType">The type to write to the console</param>
        public static void WriteHeadersToConsole(Type fileType)
        {
            var properties = fileType.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            properties.Where(p => {
                var attrs = p.GetCustomAttributes<FixedLengthAttribute>(false);
                return attrs.Count() > 0;
            }).OrderBy(p => {
                var attr = p.GetCustomAttributes<FixedLengthAttribute>(false).First();
                return attr.Ordinal;
            }).ToList().ForEach(p => {
                var attr = p.GetCustomAttributes<FixedLengthAttribute>(false).First();
                var maxLength = attr.Length;

                var value = attr.HeaderValue.SafeSubstring(0, maxLength).PadTo(maxLength);
                System.Console.WriteLine(value);
            });

            System.Console.WriteLine();
        }

        public void WriteToConsole()
        {
            var properties = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            properties.Where(p => {
                var attrs = p.GetCustomAttributes<FixedLengthAttribute>(false);
                return attrs.Count() > 0;
            }).OrderBy(p => {
                var attr = p.GetCustomAttributes<FixedLengthAttribute>(false).First();
                return attr.Ordinal;
            }).ToList().ForEach(p => {
                var attr = p.GetCustomAttributes<FixedLengthAttribute>(false).First();
                var maxLength = attr.Length;

                var value = p.GetValue(this, null).ToString().SafeSubstring(0, maxLength).PadTo(maxLength);
                System.Console.Write(value);
            });

            System.Console.WriteLine();
        }
    }
}
