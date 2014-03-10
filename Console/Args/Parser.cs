using Console.Args.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Args
{
    internal class Parser
    {
        public static IEnumerable<Option> Parse(String[] args)
        {
            var options = RawParse(args);
            options = EnsureConsistency(options);

            return options;
        }

        /// <summary>
        /// Performs a raw parsing of the arguments, converting them from the string array into objects
        /// </summary>
        /// <param name="args">The string array to parse</param>
        /// <returns>populated objects</returns>
        private static IEnumerable<Option> RawParse(String[] args)
        {
            var delim = ConfigSection.Current.OptionDelimiter;
            var q = new Queue<String>(args);

            var opt = new Option();
            var options = new List<Option>();

            if(q.Count > 0)
            {
                var firstElem = q.Dequeue();
                if(firstElem.StartsWith(delim))
                { opt.Name = firstElem.Replace(delim, String.Empty); }
            }

            while (q.Count > 0)
            {
                var elem = q.Dequeue();
                if (elem.StartsWith(delim))
                {
                    options.Add(opt);
                    opt = new Option();
                    opt.Name = elem.Replace(delim, String.Empty);
                }
                else
                { opt.AddArgument(elem); }
            }

            if(String.IsNullOrWhiteSpace(opt.Name) == false)
            { options.Add(opt); }

            return options;
        }

        /// <summary>
        /// Ensures consistency among the options by replacing the short name (if used) with the long name equivalent
        /// </summary>
        /// <param name="options">The options to ensure consistency among</param>
        /// <returns>consistent objects</returns>
        private static IEnumerable<Option> EnsureConsistency(IEnumerable<Option> options)
        {
            foreach(var opt in options)
            {
                var supportedOption = ConfigSection.Current.Options.Cast<Config.ConfigOption>().Where(o => o.ShortName == opt.Name).FirstOrDefault();

                if(supportedOption == null)
                { continue; } //option was already using the long name

                opt.Name = supportedOption.LongName;
            }

            return options;
        }
    }
}
