using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geocoding.Core;
using System.IO;
using System.Collections.Generic;
using Geocoding.Contracts;
using System.Linq;

namespace Geocoding.IO.Testing
{
    [TestClass]
    public class IndexFileWriterTestSuite
    {
        [TestMethod]
        public void TestWritingSimpleRecord()
        {
            var records = new List<IReferenceRecord>();
            var record = new ReferenceRecord();
            const string Key = @"Name";
            const string Value = @"Alexanderplatz";
            record.Properties.Add(Key, Value);
            records.Add(record);

            var indexWriter = new IndexFileWriter();
            var indexFile = new FileInfo(Path.GetTempFileName());
            indexWriter.WriteFile(indexFile, records);

            var indexReader = new IndexFileReader();
            var writtenRecords = indexReader.ReadFile(indexFile);
            var writtenRecord = Enumerable.First<IReferenceRecord>(writtenRecords);
            Assert.AreEqual(record.Properties.Count, writtenRecord.Properties.Count, @"The number of properties do not match!");
            Assert.IsTrue(writtenRecord.Properties.ContainsKey(Key), @"There is no property having a key equal to 'Name'!");
            Assert.AreEqual(record.Properties[Key], writtenRecord.Properties[Key], @"The property values do not match!");
        }

        [TestMethod]
        public void TestWritingCsvRecords()
        {
            var reader = new CsvFileReader();
            var dataset = reader.ReadFile(new FileInfo(@"data/ReferenceDataset1.csv"), true, ',');
            Assert.AreEqual(1, dataset.Records.Count, @"Record count is wrong!");

            var record = Enumerable.First<IReferenceRecord>(dataset.Records);
            const string Key = @"Name";

            var indexWriter = new IndexFileWriter();
            var indexFile = new FileInfo(Path.GetTempFileName());
            indexWriter.WriteFile(indexFile, dataset.Records);

            var indexReader = new IndexFileReader();
            var writtenRecords = indexReader.ReadFile(indexFile);
            var writtenRecord = Enumerable.First<IReferenceRecord>(writtenRecords);
            Assert.AreEqual(record.Properties.Count, writtenRecord.Properties.Count, @"The number of properties do not match!");
            Assert.IsTrue(writtenRecord.Properties.ContainsKey(@"Name"), @"There is no property having a key equal to 'Name'!");
            Assert.AreEqual(record.Properties[Key], writtenRecord.Properties[Key], @"The property values do not match!");
        }
    }
}
