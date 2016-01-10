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
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Geocoding.Contracts;

namespace Geocoding.Core.Testing
{
    /// <summary>
    /// Tests for the <see cref="Geocording.Core.ReferenceDataset"/> implementation.
    /// </summary>
    [TestClass]
    public class ReferenceDatasetTestSuite
    {
        private static Random random = new Random();

        private static PointGeometry CreateRandomPoint()
        {
            return new PointGeometry { X = -180.0 + (random.NextDouble() * 360.0), Y = -90.0 + (random.NextDouble() * 180.0), Wkid = 4326 };
        }

        private static ReferenceDataset CreateRandomDataset(ulong recordCount)
        {
            var referenceDataset = new ReferenceDataset();
            for (ulong index = 0; index < recordCount; index++)
            {
                var record = new ReferenceRecord { Geometry = CreateRandomPoint() };
                record.Properties.Add(@"Name", @"Alexanderplatz");

                referenceDataset.Records.Add(record);
            }
            return referenceDataset;
        }

        [TestMethod]
        public void TestCreateSmallDataset()
        {
            var referenceDataset = CreateRandomDataset(1000);
        }

        [TestMethod]
        public void TestCreateMediumDataset()
        {
            var referenceDataset = CreateRandomDataset((ulong) 1e5);
        }

        [TestMethod]
        public void TestCreateHugeDataset()
        {
            var referenceDataset = CreateRandomDataset((ulong) 1e8);
        }

        [TestMethod]
        public void TestCreateSinglePropertyBuilder()
        {
            const string Key = @"Name";
            var recordBuilder = new SinglePropertyRecordBuilder(Key);

            IReferenceRecord record = new ReferenceRecord();
            record = recordBuilder.BuildRecord(record, Key, string.Empty);
            Assert.AreEqual(1, record.Properties.Count, @"The property count does not match!");
            Assert.AreEqual(string.Empty, record.Properties[Key], @"The property value does not match!");

            const string Value = @"Alexanderplatz";
            record = recordBuilder.BuildRecord(record, Key, Value);
            Assert.AreEqual(1, record.Properties.Count, @"The property count does not match!");
            Assert.AreEqual(Value, record.Properties[Key], @"The property value does not match!");
        }
    }
}
