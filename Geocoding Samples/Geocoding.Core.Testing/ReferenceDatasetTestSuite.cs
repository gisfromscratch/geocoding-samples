using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
    }
}
