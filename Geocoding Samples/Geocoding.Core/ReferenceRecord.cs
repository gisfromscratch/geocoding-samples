using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocoding.Core
{
    /// <summary>
    /// Represents a record having properties and a point geometry.
    /// </summary>
    public class ReferenceRecord
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
        public PointGeometry Geometry { get; set; }
    }
}
