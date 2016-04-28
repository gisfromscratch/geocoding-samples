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

using Geocoding.ServiceApp.Properties;
using Geocoding.Services;
using Npgsql;
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
            try
            {
                ApplyOnConnection(connection =>
                {
                    try
                    {
                        using (var command = new NpgsqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandText = @"SELECT name FROM geonames_utf8 LIMIT 10";
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var value = reader[@"name"];
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                });
            }
            catch (Exception ex)
            {
            }
            return Enumerable.Empty<AddressCandidate>().ToList();
        }

        private void ApplyOnConnection(Action<NpgsqlConnection> connectionAction)
        {
            var connectionString = Environment.GetEnvironmentVariable(@"PostgresConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = Settings.Default.PostgresConnectionString;
            }
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                connectionAction(connection);
                connection.Close();
            }
        }
    }
}
