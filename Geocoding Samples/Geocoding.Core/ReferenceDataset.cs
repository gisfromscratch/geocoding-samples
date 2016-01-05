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
            Records = new List<ReferenceRecord>();
        }

        /// <summary>
        /// The records of this dataset.
        /// </summary>
        public ICollection<ReferenceRecord> Records { get; set; }
    }
}
