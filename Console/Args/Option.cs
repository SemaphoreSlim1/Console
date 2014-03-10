using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Args
{
    public class Option
    {
        public String Name { get; internal set; }
        public IEnumerable<String> Arguments { get; internal set; }

        internal void AddArgument(String value)
        {
            ((List<String>)Arguments).Add(value);
        }

        public Option()
        {
            Arguments = new List<String>();
        }

        public static IEnumerable<Option> Parse(String[] args)
        {
            var opts = Parser.Parse(args);
            var requiredsPresent = Validator.RequiredArePresent(opts);
            var valid = requiredsPresent && Validator.OptionsAreValid(opts);

            if(!valid)
            { throw new ArgumentException("Arguments are not valid"); }

            return opts;
        }
    }
}
