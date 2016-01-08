﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Geocoding.Core;

namespace Geocoding.IO.Testing
{
    /// <summary>
    /// Represents tests for reading CSV files.
    /// </summary>
    [TestClass]
    public class CsvFileReaderTestSuite
    {
        [TestMethod]
        public void TestCsvFileRead()
        {
            var reader = new CsvFileReader();
            var dataset = reader.ReadFile(new FileInfo(@"data/ReferenceDataset1.csv"), true, ',');
            Assert.AreEqual(1, dataset.Records.Count, @"Record count is wrong!");
        }

        [TestMethod]
        public void TestCsvFileReadUsingSoundex()
        {
            var reader = new CsvFileReader();
            var dataset = reader.ReadFile(new FileInfo(@"data/ReferenceDataset1.csv"), true, ',', new SoundexValueFactory(5));
            Assert.AreEqual(1, dataset.Records.Count, @"Record count is wrong!");
        }
    }
}
