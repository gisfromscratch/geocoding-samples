using Geocoding.Core;
using Geocoding.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocoding.ConsoleApp
{
    /// <summary>
    /// Represents a console applicaton used for geocoding files.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (4 != args.Length)
            {
                Console.Error.WriteLine(@"Usage: -f <csv_file> -r <csv_reference_file>");
                return;
            }

            var csvFileReader = new CsvFileReader();
            ReferenceDataset referenceDataset = null;
            for (var index = 0; index < args.Length - 1; index += 2)
            {
                if (0 == string.Compare(args[index], @"-f"))
                {
                    
                }
                else if (0 == string.Compare(args[index], @"-r"))
                {
                    referenceDataset = csvFileReader.ReadFile(new FileInfo(args[index + 1]), false, '\t');
                }
            }
        }
    }
}
