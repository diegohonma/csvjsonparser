using CSVJsonParser.Application;
using NUnit.Framework;
using System.IO;

namespace CSVJsonParser.Tests.CSVJsonParser.Application
{
    internal class CsvReaderServiceShould
    {
        private CsvReaderService _csvReaderService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _csvReaderService = new CsvReaderService();
        }

        [Test]
        public void ReturnEmptyWhenFileDoesNotExists()
        {
            var response =
                _csvReaderService.ReadLines(
                    new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, @"Samples\Csv\TESTE.csv")));

            Assert.IsEmpty(response);
        }

        [Test]
        public void ReturnEmptyWhenFileExtensionNotCsv()
        {
            var response =
                _csvReaderService.ReadLines(
                    new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, @"Samples\Json\BookingJSONExample.json")));

            Assert.IsEmpty(response);
        }

        [Test]
        public void ReturnCsvLines()
        {
            var response =
                _csvReaderService.ReadLines(
                    new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, @"Samples\Csv\BookingCSVExample.csv")));

            Assert.IsTrue(response.Length > 0);
        }
    }
}
