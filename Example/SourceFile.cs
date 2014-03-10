using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class SourceFile
    {
        public String Field1 { get; set; }
        public String Field2 { get; set; }
        public String Field3 { get; set; }

        public SourceFile(String line)
        {
            var fields = line.Split(new String[] { "," }, StringSplitOptions.None);

            Field1 = fields[0];
            Field2 = fields[1];
            Field3 = fields[2];
        }
    }
}
