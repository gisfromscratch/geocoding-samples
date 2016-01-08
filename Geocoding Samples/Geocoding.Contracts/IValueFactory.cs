using System;
using System.Collections.Generic;
using System.Linq;
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
