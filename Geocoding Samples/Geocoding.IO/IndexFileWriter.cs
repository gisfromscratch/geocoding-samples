using Geocoding.Contracts;
/*
 * Copyright 2016 Jan Tschada
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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
    /// Represents a file writer for writing index files.
    /// </summary>
    public class IndexFileWriter
    {
        /// <summary>
        /// Writes records to a file.
        /// </summary>
        /// <param name="indexFile">The index file which should be created.</param>
        /// <param name="records">The records which should be written to the file.</param>
        public void WriteFile(FileInfo indexFile, IEnumerable<IReferenceRecord> records)
        {
            using (var fileStream = indexFile.OpenWrite())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, records);
            }
        }
    }
}
