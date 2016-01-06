using System;
using System.Collections.Generic;
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
            if (2 != args.Length)
            {
                Console.Error.WriteLine(@"Usage: -f <csv_file>");
                return;
            }

            for (var index = 0; index < args.Length; index += 2)
            {
                if (0 == string.Compare(args[index], @"-f"))
                {
                    
                }
            }
        }
    }
}
