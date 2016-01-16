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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocoding.Core
{
    /// <summary>
    /// Represents a record mapper using a single property.
    /// </summary>
    public class SinglePropertyRecordMapper : IRecordMapper<string>
    {
        private readonly string _propertyName;
        private readonly IValueFactory _valueFactory;

        /// <summary>
        /// Creates a new mapper instance using a single property name and a value factory.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="valueFactory">The value factory for creating the property value.</param>
        public SinglePropertyRecordMapper(string propertyName, IValueFactory valueFactory = null)
        {
            _propertyName = propertyName;
            _valueFactory = valueFactory;
        }

        public string Map(IReferenceRecord record)
        {
            if (record.Properties.ContainsKey(_propertyName))
            {
                if (null == _valueFactory)
                {
                    return record.Properties[_propertyName];
                }
                else
                {
                    return _valueFactory.CreateValue(record.Properties[_propertyName]);
                }
            }

            return string.Empty;
        }
    }
}
