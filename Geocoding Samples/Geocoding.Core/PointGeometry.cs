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
    public class PointGeometry
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
