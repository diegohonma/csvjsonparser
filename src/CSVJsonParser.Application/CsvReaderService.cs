using CSVJsonParser.Application.Interfaces;
using System.IO;

namespace CSVJsonParser.Application
{
    public class CsvReaderService : ICsvReaderService
    {
        public string[] ReadLines(FileInfo csvFileInfo)
            => csvFileInfo.Exists && csvFileInfo.Extension.Equals(".csv")
                ? File.ReadAllLines(csvFileInfo.FullName)
                : new string[0];
    }
}
