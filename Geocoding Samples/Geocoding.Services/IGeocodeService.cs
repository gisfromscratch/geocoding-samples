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
using System.Collections.Generic;
using System.ServiceModel;

namespace Geocoding.Services
{
    /// <summary>
    /// Offers the geocode service functionality.
    /// </summary>
    [ServiceContract]
    public interface IGeocodeService
    {
        /// <summary>
        /// Finds the address candidates.
        /// </summary>
        /// <param name="addressFieldsInput">The input values for finding the candidates.</param>
        /// <param name="addressFieldsOutput">A list of names which should be used for filtering the returned attributes.</param>
        /// <returns>A list of address candidates.</returns>
        /// <remarks>
        /// Uses the <see cref="List{T}"/> and <see cref="Dictionary{TKey, TValue}"/> classes instead of the <see cref="IList{T}"/> and <see cref="IDictionary{TKey, TValue}"/> interfaces.
        /// Otherwise the default WCF serialization fails.
        /// </remarks>
        [OperationContract]
        List<AddressCandidate> FindAddressCandidates(Dictionary<string, string> addressFieldsInput, List<string> addressFieldsOutput);
    }
}
