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
using System.Runtime.Serialization;

namespace Geocoding.Services
{
    /// <summary>
    /// Represents a point geometry as a location without having a spatial reference.
    /// </summary>
    [DataContract]
    public class PointLocation : IPoint
    {
        /// <summary>
        /// The x coodinate of this location.
        /// </summary>
        [DataMember]
        public double X { get; set; }

        /// <summary>
        /// The y coordinate of this location.
        /// </summary>
        [DataMember]
        public double Y { get; set; }
    }
}
