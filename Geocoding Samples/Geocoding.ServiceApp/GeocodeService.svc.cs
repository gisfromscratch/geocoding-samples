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

using Geocoding.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Geocoding.ServiceApp
{
    /// <summary>
    /// Represents the geocode service hosted by using WCF.
    /// </summary>
    public class GeocodeService : IGeocodeService
    {
        public List<AddressCandidate> FindAddressCandidates(Dictionary<string, string> addressFieldsInput, List<string> addressFieldsOutput)
        {
            return Enumerable.Empty<AddressCandidate>().ToList();
        }
    }
}
