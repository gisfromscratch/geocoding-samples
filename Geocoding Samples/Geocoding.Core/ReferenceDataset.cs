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
    /// Represents a reference dataset containing records.
    /// </summary>
    public class ReferenceDataset
    {
        /// <summary>
        /// Creates a new instance having no records.
        /// </summary>
        public ReferenceDataset()
        {
            Records = new List<IReferenceRecord>();
        }

        /// <summary>
        /// The records of this dataset.
        /// </summary>
        public ICollection<IReferenceRecord> Records { get; set; }
    }
}
