namespace CSVJsonParser.Application.Interfaces
{
    public interface ICreateJsonFileService
    {
        void CreateJsonFile(string jsonFilePath, string content);
    }
}
