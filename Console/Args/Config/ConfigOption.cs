using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Args.Config
{
    public class ConfigOption : ConfigurationElement
    {
        /// <summary>
        /// Gets and sets the long name for this command line option, ex. verbose
        /// </summary>
        [ConfigurationProperty("longName", DefaultValue="", IsKey=true, IsRequired=true)]
        public String LongName
        {
            get { return base["longName"].ToString(); }
            set { base["longName"] = value; }
        }

        /// <summary>
        /// Gets and sets the short name for this command line option, ex. v
        /// </summary>
        [ConfigurationProperty("shortName", DefaultValue="", IsKey=false, IsRequired=false)]
        public String ShortName
        {
            get { return base["shortName"].ToString(); }
            set { base["shortName"] = value; }
        }

        /// <summary>
        /// Gets and sets the help text for this command line option
        /// </summary>
        [ConfigurationProperty("helpText", DefaultValue="", IsKey=false, IsRequired=false)]
        public String HelpText
        {
            get { return base["helpText"].ToString(); }
            set { base["helpText"] = value; }
        }

        /// <summary>
        /// Gets and sets whether this option is required
        /// </summary>
        [ConfigurationProperty("isRequired",DefaultValue=false,IsKey=false,IsRequired=true)]
        public Boolean IsRequired
        {
            get { return Convert.ToBoolean(base["isRequired"]); }
            set { base["isRequired"] = value; }
        }

        /// <summary>
        /// Gets and sets the minimum amount of arguments that should be supplied to this option
        /// </summary>
        [ConfigurationProperty("minArguments", DefaultValue=ArgumentsConfiguration.Zero, IsKey=false, IsRequired=true)]
        public ArgumentsConfiguration MinArguments
        {
            get { return (ArgumentsConfiguration)Enum.Parse(typeof(ArgumentsConfiguration), base["minArguments"].ToString()); }
            set { base["minArguments"] = value; }
        }

        /// <summary>
        /// Gets and sets the maximum amount of arguments that should be supplied to this option
        /// </summary>
        [ConfigurationProperty("maxArguments", DefaultValue=ArgumentsConfiguration.Zero, IsKey=false, IsRequired=true)]
        public ArgumentsConfiguration MaxArguments
        {
            get { return (ArgumentsConfiguration)Enum.Parse(typeof(ArgumentsConfiguration), base["maxArguments"].ToString()); }
            set { base["maxArguments"] = value; }
        }
    }
}
