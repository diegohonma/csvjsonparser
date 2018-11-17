using CSVJsonParser.Application.Interfaces;
using CSVJsonParser.Application.Model;
using CSVJsonParser.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSVJsonParser.Application
{
    public class CsvBookingParserService : ICsvClassParserService
    {
        public T Parse<T>(string[] csvLines)
        {
            var bookings = new Dictionary<long, Booking>();

            try
            {
                for (var i = 0; i < csvLines.Length; i++)
                {
                    if (i == 0) continue;

                    var csvLine = csvLines[i];
                    var fields = csvLine.Split(';');

                    if (fields.Length < 5) continue;
                    
                    long.TryParse(fields[0], out var bookingId);
                    DateTime.TryParse(fields[1], out var bookingCheckIn);
                    DateTime.TryParse(fields[2], out var bookingCheckOut);
                    var guestName = fields[3];
                    var guestEmail = fields[4];

                    var booking = new Booking(
                        id: bookingId,
                        checkIn: bookingCheckIn,
                        checkOut: bookingCheckOut,
                        guest: new Guest(guestName, guestEmail)
                    );

                    if (booking.IsValid())
                    {
                        var existingBook = bookings.GetValueOrDefault(booking.Id);

                        if (existingBook != null)
                        {
                            booking.Guest.ForEach(g => existingBook.AddGuest(g));
                        }
                        else
                        {
                            bookings.Add(booking.Id, booking);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao realizar o parse do csv para o objeto {typeof(T)} {e}");
                throw;
            }

            return (T)Convert.ChangeType(new BookingsModel(bookings.Values.ToList()), typeof(T));
        }
    }
}
