using Geocoding.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Geocoding.IO
{
    /// <summary>
    /// Represents a reader for index files.
    /// </summary>
    public class IndexFileReader
    {
        /// <summary>
        /// Reads records from an index file.
        /// </summary>
        /// <param name="indexFile">The index file containing the records.</param>
        /// <returns>The records of the specified index file.</returns>
        public IEnumerable<IReferenceRecord> ReadFile(FileInfo indexFile)
        {
            using (var fileStream = indexFile.OpenRead())
            {
                var binaryFormatter = new BinaryFormatter();
                return binaryFormatter.Deserialize(fileStream) as IEnumerable<IReferenceRecord>;
            }
        }
    }
}
