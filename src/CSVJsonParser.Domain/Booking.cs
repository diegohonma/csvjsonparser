using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using CSVJsonParser.Domain.Helpers;

namespace CSVJsonParser.Domain
{
    public class Booking
    {
        public Booking(long id, DateTime checkIn, DateTime checkOut, Guest guest)
        {
            Id = id;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Guest = new List<Guest> { guest };
        }

        public long Id { get; }

        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime CheckIn { get; }

        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime CheckOut { get; }

        public List<Guest> Guest { get; }
        
        public bool IsValid()
            => Id > 0 && !new [] { CheckIn, CheckOut }.Contains(DateTime.MinValue) && Guest.All(g => g.IsValid());
        
        public void AddGuest(Guest guest) => Guest.Add(guest);
    }
}
