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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocoding.Core
{
    /// <summary>
    /// Represents a record builder using a single property.
    /// </summary>
    public class SinglePropertyRecordBuilder : IRecordBuilder
    {
        private readonly string _key;

        /// <summary>
        /// Creates a new builder using only a single property.
        /// </summary>
        /// <param name="key">The name of the property which should be used.</param>
        public SinglePropertyRecordBuilder(string key)
        {
            _key = key;
        }

        public IReferenceRecord BuildRecord(IReferenceRecord templateRecord, string key, string value)
        {
            if (0 != string.CompareOrdinal(_key, key))
            {
                return templateRecord;
            }

            if (templateRecord.Properties.ContainsKey(key))
            {
                templateRecord.Properties[key] = value;
            }
            else
            {
                templateRecord.Properties.Add(key, value);
            }

            return templateRecord;
        }
    }
}
