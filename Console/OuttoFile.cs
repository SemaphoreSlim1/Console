using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class OutToFile : IDisposable
    {
        private StreamWriter fileOutput;
        private TextWriter oldOutput;

        public OutToFile(String path)
        {
            oldOutput = System.Console.Out;
            fileOutput = new StreamWriter(new FileStream(path, FileMode.Create));
            fileOutput.AutoFlush = true;
            System.Console.SetOut(fileOutput);
        }

        public void Dispose()
        {
            System.Console.SetOut(oldOutput);
            fileOutput.Close();
            fileOutput.Dispose();
        }
    }
}
