using Geocoding.Contracts;
using System;
using System.Collections.Generic;
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
namespace Geocoding.Core
{
    /// <summary>
    /// Represents a record having properties and a point geometry.
    /// </summary>
    public class ReferenceRecord : IReferenceRecord
    {
        /// <summary>
        /// Creates a new instance having no properties and an empty geometry.
        /// </summary>
        public ReferenceRecord()
        {
            Properties = new Dictionary<string, string>();
            Geometry = new PointGeometry();
        }

        /// <summary>
        /// The properties of this record.
        /// </summary>
        public IDictionary<string, string> Properties { get; set; }

        /// <summary>
        /// The point geometry of this record.
        /// </summary>
        public IPointGeometry Geometry { get; set; }
    }
}
