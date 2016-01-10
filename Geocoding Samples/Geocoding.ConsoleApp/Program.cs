﻿using Geocoding.Core;
using Geocoding.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
namespace Geocoding.ConsoleApp
{
    /// <summary>
    /// Represents a console applicaton used for geocoding files.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (6 != args.Length)
            {
                Console.Error.WriteLine(@"Usage: -f <csv_file> -r <csv_reference_file> -i <index_property>");
                return;
            }

            FileInfo inputFile = null;
            FileInfo referenceFile = null;
            var indexPropertyName = string.Empty;
            for (var index = 0; index < args.Length - 1; index += 2)
            {
                if (0 == string.Compare(args[index], @"-f"))
                {
                    
                }
                else if (0 == string.Compare(args[index], @"-r"))
                {
                    referenceFile = new FileInfo(args[index + 1]);
                }
                else if (0 == string.Compare(args[index], @"-i"))
                {
                    indexPropertyName = args[index + 1];
                }
            }

            if (null != referenceFile)
            {
                var csvFileReader = new CsvFileReader();
                if (!string.IsNullOrEmpty(indexPropertyName))
                {
                    csvFileReader.RecordBuilder = new SinglePropertyRecordBuilder(indexPropertyName);
                    csvFileReader.ValueFactory = new SoundexValueFactory(5);
                }
                var referenceDataset = csvFileReader.ReadFile(referenceFile, false, '\t');
            }
        }
    }
}
