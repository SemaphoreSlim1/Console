using Console.Args.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Args
{
    internal class Validator
    {
        public static Boolean RequiredArePresent(IEnumerable<Option> options)
        {
            var requiredOptions = ConfigSection.Current.Options.Cast<Config.ConfigOption>().Where(o => o.IsRequired == true);

            var success = true;
            foreach(var requiredOption in requiredOptions)
            {
                var match = options.Where(o => o.Name == requiredOption.LongName || o.Name == requiredOption.ShortName).Count() > 0;
                success = success && match;
            }

            return success;
        }

        public static Boolean OptionsAreValid(IEnumerable<Option> options)
        {
            var success = true;
            foreach(var opt in options)
            {
                //find the configured option for this user-specified option
                var supportedOption = ConfigSection.Current.Options.Cast<Config.ConfigOption>().Where(o => o.LongName == opt.Name || o.ShortName == opt.Name).FirstOrDefault();
                if(supportedOption == null)
                {
                    success = false;
                    break;
                }

                var minSuccess = true;
                switch(supportedOption.MinArguments)
                {
                    case Console.Args.Config.ArgumentsConfiguration.One:
                        minSuccess = opt.Arguments.Count() >= 1;
                        break;
                    case Console.Args.Config.ArgumentsConfiguration.Many:
                        minSuccess = opt.Arguments.Count() > 0;
                        break;
                    default:
                        minSuccess = true;
                        break;
                }

                var maxSuccess = true;
                switch (supportedOption.MaxArguments)
                {
                    case ArgumentsConfiguration.Zero:
                        maxSuccess = opt.Arguments.Count() == 0;
                        break;
                    case ArgumentsConfiguration.One:
                        maxSuccess = opt.Arguments.Count() <= 1;
                        break;
                    default:
                        maxSuccess = true;
                        break;
                }

                success = success && minSuccess && maxSuccess;
            }

            return success;
        }
    }
}
