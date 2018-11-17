namespace CSVJsonParser.Application.Interfaces
{
    public interface ICsvClassParserService
    {
        T Parse<T>(string[] csvLines);
    }
}
