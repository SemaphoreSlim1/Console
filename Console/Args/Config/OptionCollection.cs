using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Args.Config
{
    [ConfigurationCollection(typeof(OptionCollection))]
    public class OptionCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigOption();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as ConfigOption).LongName;
        }

        /// <summary>
        /// Gets an element at the specified index
        /// </summary>
        /// <param name="index">The index of the element to retrieve</param>
        public ConfigOption this[int index]
        {
            get { return BaseGet(index) as ConfigOption; }
        }
    }
}
