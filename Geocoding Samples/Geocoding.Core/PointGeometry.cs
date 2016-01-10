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
    /// Represents a 2D point geometry.
    /// </summary>
    public class PointGeometry : IPointGeometry
    {
        public PointGeometry()
        {
            X = double.NaN;
            Y = double.NaN;
        }

        /// <summary>
        /// <c>true</c> when this geometry has valid coordinates.
        /// </summary>
        public virtual bool IsValid
        {
            get
            {
                return !double.IsNaN(X) && !double.IsNaN(Y);
            }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public int Wkid { get; set; }
    }
}
