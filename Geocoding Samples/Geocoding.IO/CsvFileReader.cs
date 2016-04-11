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
using Geocoding.Contracts;
using Geocoding.Core;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocoding.IO
{
    /// <summary>
    /// Represents a reader for CSV files.
    /// </summary>
    public class CsvFileReader
    {
        private readonly Logger _logger;

        /// <summary>
        /// Creates a new reader instance.
        /// </summary>
        public CsvFileReader()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// The record builder for adding and updating the properties.
        /// </summary>
        public IRecordBuilder RecordBuilder { get; set; }

        /// <summary>
        /// The value factory for creating the property values.
        /// </summary>
        public IValueFactory ValueFactory { get; set; }

        /// <summary>
        /// Reads a CSV file using the specified delimiter.
        /// </summary>
        /// <param name="fileInfo">The CSV file to read.</param>
        /// <param name="readHeader"><c>true</c> if the first row contains the header.</param>
        /// <param name="delimiter">The delimiter for the values.</param>
        /// <returns>A reference dataset.</returns>
        public ReferenceDataset ReadFile(FileInfo fileInfo, bool readHeader, char delimiter)
        {
            var dataset = new ReferenceDataset();
            var header = new List<string>();
            using (var reader = new StreamReader(fileInfo.OpenRead()))
            {
                string line;
                const int ChunkSize = 1000000;
                while (null != (line = reader.ReadLine()))
                {
                    var splittedLine = line.Split(delimiter);
                    if (!header.Any())
                    {
                        // Read the header
                        if (readHeader)
                        {
                            foreach (var headerValue in splittedLine)
                            {
                                header.Add(headerValue);
                            }
                            continue;
                        }
                        else
                        {
                            for (var index = 0; index < splittedLine.Length; index++)
                            {
                                header.Add(string.Format(@"FIELD{0}", index + 1));
                            }
                        }
                    }

                    if (header.Count == splittedLine.Length)
                    {
                        try
                        {
                            // Read the values
                            IReferenceRecord record = new ReferenceRecord();
                            for (var index = 0; index < header.Count; index++)
                            {
                                var key = header[index];
                                var value = splittedLine[index];
                                if (null != ValueFactory)
                                {
                                    value = ValueFactory.CreateValue(value);
                                }
                                if (null != RecordBuilder)
                                {
                                    record = RecordBuilder.BuildRecord(record, key, value);
                                }
                                else if (!record.Properties.ContainsKey(key))
                                {
                                    record.Properties.Add(key, value);
                                }
                            }

                            // Add the record
                            dataset.Records.Add(record);
                            if (0 == dataset.Records.Count % ChunkSize)
                            {
                                _logger.Info(@"{0} records created.", dataset.Records.Count);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(@"Error during record creation! '{0}'", ex.Message);
                        }
                    }
                }
            }
            return dataset;
        }

        /// <summary>
        /// Streams all records of a CSV file using the specified delimiter.
        /// </summary>
        /// <param name="fileInfo">The CSV file to read.</param>
        /// <param name="readHeader"><c>true</c> if the first row contains the header.</param>
        /// <param name="delimiter">The delimiter for the values.</param>
        /// <returns>The records of this file.</returns>
        public IEnumerable<IReferenceRecord> StreamFile(FileInfo fileInfo, bool readHeader, char delimiter)
        {
            var header = new List<string>();
            using (var reader = new StreamReader(fileInfo.OpenRead()))
            {
                string line;
                const int ChunkSize = 1000000;
                while (null != (line = reader.ReadLine()))
                {
                    var splittedLine = line.Split(delimiter);
                    if (!header.Any())
                    {
                        // Read the header
                        if (readHeader)
                        {
                            foreach (var headerValue in splittedLine)
                            {
                                header.Add(headerValue);
                            }
                            continue;
                        }
                        else
                        {
                            for (var index = 0; index < splittedLine.Length; index++)
                            {
                                header.Add(string.Format(@"FIELD{0}", index + 1));
                            }
                        }
                    }

                    if (header.Count == splittedLine.Length)
                    {
                        // Read the values
                        IReferenceRecord record = new ReferenceRecord();
                        for (var index = 0; index < header.Count; index++)
                        {
                            var key = header[index];
                            var value = splittedLine[index];
                            if (null != ValueFactory)
                            {
                                value = ValueFactory.CreateValue(value);
                            }
                            if (null != RecordBuilder)
                            {
                                record = RecordBuilder.BuildRecord(record, key, value);
                            }
                            else if (!record.Properties.ContainsKey(key))
                            {
                                record.Properties.Add(key, value);
                            }
                        }

                        // Stream the record
                        yield return record;
                    }
                }
            }
        }
    }
}
