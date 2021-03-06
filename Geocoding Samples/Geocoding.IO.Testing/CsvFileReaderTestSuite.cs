﻿/*
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
            reader.RecordBuilder = new SinglePropertyRecordBuilder(@"Name");
            reader.ValueFactory = new SoundexValueFactory(5);
            var dataset = reader.ReadFile(new FileInfo(@"data/ReferenceDataset1.csv"), true, ',');
            Assert.AreEqual(1, dataset.Records.Count, @"Record count is wrong!");
            foreach (var record in dataset.Records)
            {
                Assert.AreEqual(1, record.Properties.Count, @"Property count is wrong!");
                Assert.AreEqual(@"A4253", record.Properties[@"Name"], @"Soundex code is wrong!");
            }
        }
    }
}
