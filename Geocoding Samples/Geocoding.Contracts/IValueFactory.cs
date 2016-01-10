﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Text;
using System.Threading.Tasks;

namespace Geocoding.Contracts
{
    /// <summary>
    /// Offers a factory for creating string values.
    /// </summary>
    public interface IValueFactory
    {
        /// <summary>
        /// Creates a new value using an existing value.
        /// </summary>
        /// <param name="value">The original value.</param>
        /// <returns>The new value.</returns>
        string CreateValue(string value);
    }
}
