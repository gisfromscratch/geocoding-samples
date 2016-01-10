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
    /// Represents a factory creating soundex codes from string values.
    /// </summary>
    public class SoundexValueFactory : IValueFactory
    {
        private readonly ushort _size;

        /// <summary>
        /// Creates a new factory instance.
        /// </summary>
        /// <param name="size">The maximum size of the soundex code.</param>
        public SoundexValueFactory(ushort size)
        {
            _size = size;
        }

        public string CreateValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            foreach (var valueChar in value.ToUpperInvariant())
            {
                if (builder.Length < 1)
                {
                    builder.Append(valueChar);
                }
                else
                {
                    switch (valueChar)
                    {
                        case 'B':
                        case 'F':
                        case 'P':
                        case 'V':
                            builder.Append("1");
                            break;

                        case 'C':
                        case 'G':
                        case 'J':
                        case 'K':
                        case 'Q':
                        case 'S':
                        case 'X':
                        case 'Z':
                            builder.Append("2");
                            break;

                        case 'D':
                        case 'T':
                            builder.Append("3");
                            break;

                        case 'L':
                            builder.Append("4");
                            break;

                        case 'M':
                        case 'N':
                            builder.Append("5");
                            break;

                        case 'R':
                            builder.Append("6");
                            break;
                    }

                    if (_size == builder.Length)
                    {
                        return builder.ToString();
                    }
                }
            }

            return builder.ToString();
        }
    }
}
