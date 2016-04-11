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
using System.Text;
using System.Threading.Tasks;

namespace Geocoding.IO
{
    /// <summary>
    /// Represents a writer for writing a directory containing index files.
    /// </summary>
    public class IndexDirectoryWriter
    {
        /// <summary>
        /// Writes index files into the specified directory.
        /// </summary>
        /// <param name="indexDirectory">The directory into which the index files should be written.</param>
        /// <param name="recordMapper">The mapper for the records.</param>
        /// <param param name="records">The records which should be written.</param>
        public void WriteDirectory(DirectoryInfo indexDirectory, IRecordMapper<string> recordMapper, IEnumerable<IReferenceRecord> records)
        {
            if (!indexDirectory.Exists)
            {
                indexDirectory.Create();
            }

            var directoryNames = new HashSet<string>();
            foreach (var directory in indexDirectory.GetDirectories())
            {
                if (!directoryNames.Contains(directory.Name))
                {
                    directoryNames.Add(directory.Name);
                }
            }
            foreach (var record in records)
            {
                var directoryName = recordMapper.Map(record);
                if (!directoryNames.Contains(directoryName))
                {
                    indexDirectory.CreateSubdirectory(directoryName);
                    directoryNames.Add(directoryName);
                }

                // Write index files into the index directory
            }
        }
    }
}
