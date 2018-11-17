using CSVJsonParser.Domain;
using System.Collections.Generic;

namespace CSVJsonParser.Application.Model
{
    public class BookingsModel
    {
        public BookingsModel(List<Booking> boookings)
        {
            Boookings = boookings;
        }

        public List<Booking> Boookings { get; }
    }
}
