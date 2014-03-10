using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Args.Config
{
    public class ConfigSection : ConfigurationSection
    {
        private static String _CurrentName;
        public static String CurrentName
        {
            get
            {
                if(String.IsNullOrWhiteSpace(_CurrentName))
                { _CurrentName = "CommandLineSettings"; }
                return _CurrentName;
            }
            set
            {
                _CurrentName = value;
                _Current = null;
            }
        }

        private static ConfigSection _Current;
        public static ConfigSection Current
        {
            get
            {
                if(_Current == null)
                {
                    try { 
                        //in partial-trust scenarios, this may not work
                        _Current = ConfigurationManager.GetSection(ConfigSection.CurrentName) as ConfigSection;
                    }catch(Exception ex)
                    {
                        //hack around it.
                        //get the path of the executing process, and open its config file
                        var exePath = System.Diagnostics.Process.GetCurrentProcess().Modules[0].ModuleName;
                        _Current = ConfigurationManager.OpenExeConfiguration(exePath).GetSection(ConfigSection.CurrentName) as ConfigSection;

                    }
                }
                return _Current;
            }
        }

        /// <summary>
        /// Gets and sets the command line options for this configuration section
        /// </summary>
        [ConfigurationProperty("Options")]
        public OptionCollection Options
        {
            get { return base["Options"] as OptionCollection; }
            set { base["Options"] = value; }
        }

        /// <summary>
        /// Gets and sets the character(s) used for delimiting options on the command line
        /// </summary>
        [ConfigurationProperty("optionDelmiter", DefaultValue="-", IsKey=false, IsRequired=false)]
        public String OptionDelimiter
        {
            get { return base["optionDelimiter"].ToString(); }
            set { base["optionDelimiter"] = value; }
        }
    }
}
