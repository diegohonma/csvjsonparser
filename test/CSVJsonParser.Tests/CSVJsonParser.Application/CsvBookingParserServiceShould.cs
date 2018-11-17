using System;
using System.Linq;
using CSVJsonParser.Application;
using CSVJsonParser.Application.Model;
using NUnit.Framework;

namespace CSVJsonParser.Tests.CSVJsonParser.Application
{
    internal class CsvBookingParserServiceShould
    {
        private CsvBookingParserService _csvBookingParserService;

        [SetUp]
        public void SetUp()
        {
            _csvBookingParserService = new CsvBookingParserService();
        }

        [Test]
        public void ReturnNoBookingsWhenNoCsvLines()
        {
            var response = _csvBookingParserService.Parse<BookingsModel>(new string[0]);

            Assert.IsEmpty(response.Boookings);
        }

        [Test]
        public void IgnoreIncompleteData()
        {
            var csvLines = new[]
            {
                "BOOKINGID;BOOKING_CHECKIN;BOOKING_CHECKOUT;GUEST_NAME;GUEST_EMAIL;",
                "1; 2018-07-01; 2018-07-10; Fulano da Silva;;"
            };

            var response = _csvBookingParserService.Parse<BookingsModel>(csvLines);

            Assert.IsEmpty(response.Boookings);
        }

        [Test]
        public void MergeGuestsSameBookingId()
        {
            var csvLines = new[]
            {
                "BOOKINGID;BOOKING_CHECKIN;BOOKING_CHECKOUT;GUEST_NAME;GUEST_EMAIL;",
                "1; 2018-07-01; 2018-07-10; Fulano da Silva;fulano@email.com;",
                "1;2018-07-01;2018-07-10;Maria Pereira;maria@email.com;"
            };

            var response = _csvBookingParserService.Parse<BookingsModel>(csvLines);

            Assert.IsTrue(response.Boookings.Count == 1);
            Assert.IsTrue(response.Boookings.First().Guest.Count == 2);
        }

        [Test]
        public void ThrownException()
        {
            Assert.Throws<NullReferenceException>(
                () => _csvBookingParserService.Parse<BookingsModel>(null));
        }
    }
}
