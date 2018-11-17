namespace CSVJsonParser.Application.Interfaces
{
    public interface ICsvJsonParserService
    {
        string Parse(string[] csvLines);
    }
}
