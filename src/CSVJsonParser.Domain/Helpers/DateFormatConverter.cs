using Newtonsoft.Json.Converters;

namespace CSVJsonParser.Domain.Helpers
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
