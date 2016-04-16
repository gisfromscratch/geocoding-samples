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
using System.Runtime.Serialization;

namespace Geocoding.Services
{
    /// <summary>
    /// Represents an address candidate.
    /// </summary>
    [DataContract]
    public class AddressCandidate
    {
        /// <summary>
        /// The single line address of this candidate.
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// The location of this candidate.
        /// </summary>
        [DataMember]
        public PointLocation Location { get; set; }

        /// <summary>
        /// The score of this candidate.
        /// </summary>
        [DataMember]
        public ushort Score { get; set; }

        /// <summary>
        /// The attributes of this candidate.
        /// </summary>
        [DataMember]
        public IDictionary<string, object> Attributes { get; set; }
    }
}
