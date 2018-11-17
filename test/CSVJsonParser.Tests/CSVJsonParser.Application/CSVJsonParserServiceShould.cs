using CSVJsonParser.Application;
using CSVJsonParser.Application.Interfaces;
using CSVJsonParser.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using CSVJsonParser.Application.Model;

namespace CSVJsonParser.Tests.CSVJsonParser.Application
{
    internal class CsvJsonParserServiceShould
    {
        private CsvJsonParserService _csvJsonParserService;

        [SetUp]
        public void SetUp()
        {
            _csvJsonParserService = new CsvJsonParserService(new Dictionary<Type, ICsvClassParserService>
            {
                { typeof(BookingsModel), new CsvBookingParserService() }
            });
        }

        [Test]
        public void ReturnCorrectJson()
        {
            var csvLines = File.ReadAllLines(
                Path.Combine(TestContext.CurrentContext.TestDirectory, @"Samples\Csv\BookingCSVExample.csv"));

            var expectedResponse = File.ReadAllText(
                Path.Combine(TestContext.CurrentContext.TestDirectory, @"Samples\Json\BookingJSONExample.json"));

            var json = _csvJsonParserService.Parse(csvLines);

            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(json);
                Assert.AreEqual(expectedResponse, json);
            });
        }
    }
}
