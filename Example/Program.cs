using Console;
using Console.Args;
using Console.FixedLength;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class Program
    {
        static void Main(string[] args)
        {
            var commandLineArgs = Option.Parse(args);

            //read the existing file, and parse it into something we can use.
            var inputFileArg = commandLineArgs.Where(arg => arg.Name == "InputFile").First();
            var filePath = inputFileArg.Arguments.First();

            var assumeHeaders = commandLineArgs.Where(arg => arg.Name == "InputHeaders").FirstOrDefault() != null;

            IEnumerable<SourceFile> sourceFiles = null;
            if(assumeHeaders)
            { sourceFiles = System.IO.File.ReadLines(filePath).Skip(1).Select(line => new SourceFile(line)); }
            else
            { sourceFiles = System.IO.File.ReadLines(filePath).Select(line => new SourceFile(line)); }

            var destFiles = sourceFiles.Select(f => new DestinationFile(f));

            var outputToConsole = commandLineArgs.Where(arg => arg.Name == "OutputFile").FirstOrDefault() == null;
            var writeHeaders = commandLineArgs.Where(arg => arg.Name == "OutputHeaders").FirstOrDefault() != null;

            if(outputToConsole)
            { WriteItems(destFiles, writeHeaders); }
            else
            {
                var outputFileName = commandLineArgs.Where(arg => arg.Name == "OutputFile").First().Arguments.First();

                using (var redirect = new OutToFile(outputFileName))
                { WriteItems(destFiles, writeHeaders); }
            }
        }

        private static void WriteItems(IEnumerable<DestinationFile> files, Boolean writeHeaders)
        {
            if(writeHeaders)
            { FixedLengthFile.WriteHeadersToConsole(typeof(DestinationFile)); }

            foreach(var file in files)
            { file.WriteToConsole(); }
        }
    }
}
