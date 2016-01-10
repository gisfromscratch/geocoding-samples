﻿/*
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

namespace Geocoding.Contracts
{
    /// <summary>
    /// Offers the building of records.
    /// </summary>
    public interface IRecordBuilder
    {
        /// <summary>
        /// Builds the record using keys and values for updating the properties.
        /// </summary>
        /// <param name="templateRecord">The template record whose properties should be updated.</param>
        /// <param name="key">The key which should be used for building the record.</param>
        /// <param name="value">The value which should be used for building the record.</param>
        /// <returns>The updated record instance.</returns>
        IReferenceRecord Build(IReferenceRecord templateRecord, string key, string value);
    }
}
