using CSVJsonParser.Application.Interfaces;
using CSVJsonParser.Application.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CSVJsonParser.Application
{
    public class CsvJsonParserService : ICsvJsonParserService
    {
        private readonly Dictionary<Type, ICsvClassParserService> _csvClassParserServices;

        public CsvJsonParserService(Dictionary<Type, ICsvClassParserService> csvClassParserServices)
        {
            _csvClassParserServices = csvClassParserServices;
        }

        public string Parse(string[] csvLines)
        {
            var bookings = _csvClassParserServices[typeof(BookingsModel)].Parse<BookingsModel>(csvLines);
            return JsonConvert.SerializeObject(bookings, Formatting.Indented);
        }
    }
}
