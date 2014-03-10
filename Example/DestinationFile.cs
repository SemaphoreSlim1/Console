using Console.FixedLength;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class DestinationFile : FixedLengthFile
    {
        [FixedLength(Ordinal=0, Length=10, HeaderValue="Field A")]
        public String FieldA { get; set; }

        [FixedLength(Ordinal=1, Length=15, HeaderValue="Field B")]
        public String FieldB { get; set; }

        [FixedLength(Ordinal=2, Length=8, HeaderValue="Field C")]
        public String FieldC { get; set; }

        public DestinationFile(SourceFile f)
        {
            InstantiateDefaults();

            this.FieldA = f.Field1;
            this.FieldB = f.Field2;
            this.FieldC = f.Field3;
        }
    }
}
