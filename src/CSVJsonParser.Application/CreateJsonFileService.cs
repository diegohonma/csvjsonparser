using System;
using CSVJsonParser.Application.Interfaces;
using System.IO;

namespace CSVJsonParser.Application
{
    public class CreateJsonFileService : ICreateJsonFileService
    {
        public void CreateJsonFile(string jsonFilePath, string content)
            => File.WriteAllText(Path.Combine(jsonFilePath, $"{DateTime.Now:yyyyMMddHHmmss}.json"), content);
    }
}
